using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Classes.Algorithms.Filter;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.Algorithms.ObjectFetching;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.Types.Exceptions;
using Loot3Framework.Types.Classes.HelperClasses;


namespace Loot3Vorbereitung
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ObjectFetcherAccess<int>.GetObjects().DoAction(o => Console.WriteLine(o));
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            GlobalItems.Instance.AllTypeNames.DoAction(n => checkedListBox1.Items.Add(n, true));
            GlobalItems.Instance.AllRarityNames.DoAction(r => checkedListBox2.Items.Add(r, true));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PR_PartionLoot<string> looter = new PR_PartionLoot<string>(new DefaultRarityTable());
                listBox1.Items.Add(
                    GlobalItems.Instance.GetLoot(
                        looter,
                        new ConfigurableFilter(
                            _nameContains: textBox1.Text,
                            _allowedTypes: checkedListBox1.CheckedItems.DoFunc(i => i as string),
                            _allowedRarities: checkedListBox2.CheckedItems.DoFunc(i => i as string),
                            _allowQuestItems: checkBox1.Checked
                        )
                    ).Item
                );

                XmlSerializer xml = new XmlSerializer(typeof(FusionContainer<string, int>[]));
                using (StreamWriter sr = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "lastLootRange.sv")))
                {
                    xml.Serialize(sr, looter.InnerAlgorithm.LastItemNames.Fuse(looter.InnerAlgorithm.LastItemRarities));
                    sr.Close();
                }

                int j = 0;

                Console.WriteLine(
                    "-> " +
                    looter.LastRarity +
                    " ::rarity had probability of: " +
                    Math.Round(looter.LastProbability, 2) +
                    "% \nwith range of: " +
                    looter.LastRarityRange +
                    " \nand rarity-roll: " +
                    looter.LastRoll +
                    " /\nitem-roll: " +
                    looter.InnerAlgorithm.LastRoll +
                    " \nin total range of: [" +
                    looter.InnerAlgorithm.LastChain.Intervalls.First().X +
                    ";" +
                    looter.InnerAlgorithm.LastChain.Intervalls.Last().Y +
                    "] \nand local range of: " +
                    looter.InnerAlgorithm.LastIntervall +
                    " \nwith all items: " +
                    looter.InnerAlgorithm.LastItemNames.Fuse(looter.InnerAlgorithm.LastItemRarities).SumUp((f) => f.ToString(), (a, b) => a + "," + b) + 
                    " \nor " +
                    string.Join(",", looter.InnerAlgorithm.LastItemNames.DoFunc(n => "[" + n + ";" + looter.InnerAlgorithm.LastItemRarities[j++] + "]"))
                    );
            }
            catch (NoMatchingLootException)
            {
                listBox1.Items.Add("No Matching Items found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalItems.Instance.AddAllLootObjects();
            //GlobalItems.Instance.Add(new LootObjectContainer<string>("Mettwurst").SetProps(null, true, "Mettwurst", 599, "Artefakt"));
            //GlobalItems.Instance.Add(new LootFunctionContainer<string>(() => GlobalRandom.Next(13, 667) + " Euronen").SetProps(null, true, "Func", 400, "LootFunction"));
            MainForm_Load(null, null);
        }
    }
}

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
using Loot3Framework.Types.Classes.Comperators;


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
            List<string> rars = new List<string>();
            List<int> rarCounts = new List<int>();

            string[] aa;
            int[] bb;

            new string[] { "eins", "zwei", "drei" }.Fuse(new int[] { 1, 2, 3 }).DeFuse(out aa, out bb);

            for (int counter = 0; counter < 1000; counter++)
            {
                try
                {
                    PR_PartionLoot<string, PartitionLoot<string>> looter = new PR_PartionLoot<string, PartitionLoot<string>>(DefaultRarityTable.SharedInstance, PartitionLoot<string>.SharedInstance, checkedListBox2.CheckedItems.DoFunc(i => i as string));
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

                    if (!rars.Contains(looter.LastRarity))
                    {
                        rars.Add(looter.LastRarity);
                        rarCounts.Add(0);
                    }
                    rarCounts[rars.IndexOf(looter.LastRarity)]++;

                    XmlSerializer xml = new XmlSerializer(typeof(FusionContainer<string, int>[]));
                    using (StreamWriter sr = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "lastLootRange.sv")))
                    {
                        xml.Serialize(sr, looter.InnerAlgorithm.LastItemNames.Fuse(looter.InnerAlgorithm.LastItemRarities));
                        sr.Close();
                    }

                    int j = 0;
                    Console.WriteLine(
                        "(" +
                        counter +
                        ")-> " +
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
                        string.Join(",", looter.InnerAlgorithm.LastItemNames.DoFunc(n => "[" + n + ";" + looter.InnerAlgorithm.LastItemRarities[j++] + "]")) +
                        " \nor " +
                        string.Join(",", looter.InnerAlgorithm.LastItemNames.FuseInto(looter.InnerAlgorithm.LastItemRarities, (n, r) => "[" + n + ";" + r + "]"))
                        );
                }
                catch (NoMatchingLootException)
                {
                    listBox1.Items.Add("No Matching Items found");
                }
            }
            Comparer<FusionContainer<string, int>> comparer = Comparer<FusionContainer<string, int>>.Create((f1, f2) => new RarTableOrderComperator(DefaultRarityTable.SharedInstance).Compare(f1.Item1, f2.Item1));
            Console.WriteLine("Results : " + string.Join(",", rars.Fuse(rarCounts).DoWith(f => Array.Sort(f, comparer)).DoFunc(f => "{" + f.Item1 + "," + f.Item2 + "}")));
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

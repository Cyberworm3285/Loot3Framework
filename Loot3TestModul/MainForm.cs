using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Classes.Algorithms.Filter;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.RarityTables;
using Loot3Framework.Types.Exceptions;
using Loot3Framework.Types.Classes.HelperClasses;
using Loot3Framework.Types.Classes.Comperators;
using Loot3Framework.Interfaces;

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
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            GlobalItems.Instance.AllTypeNames.DoAction(n => checkedListBox1.Items.Add(n, true));
            GlobalItems.Instance.AllRarityNames.DoAction(r => checkedListBox2.Items.Add(r, true));
            GlobalItems.Instance.AllLoot.DoAction(l => checkedListBox3.Items.Add(l, true));
            GlobalItems.Instance.OnLootChanged +=
                (send, args) =>
                {
                    Console.WriteLine("Items changed! (" + args.ChangedLoot.Count() + ": " + Enum.GetName(args.ChangeType.GetType(), args.ChangeType) + ")");
                    checkedListBox1.Items.Clear();
                    checkedListBox2.Items.Clear();
                    checkedListBox3.Items.Clear();
                    GlobalItems.Instance.AllTypeNames.DoAction(n => checkedListBox1.Items.Add(n, true));
                    GlobalItems.Instance.AllRarityNames.DoAction(r => checkedListBox2.Items.Add(r, true));
                    GlobalItems.Instance.AllLoot.DoAction(l => checkedListBox3.Items.Add(l, true));
                };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> rars = new List<string>();
            List<int> rarCounts = new List<int>();

            GlobalItems.Instance.AllowedLoot = checkedListBox3.CheckedItems.Cast<ILootable<string>>().ToArray();

            //string[] aa = new string[]  { "eins",   "drei", "zwei", "minus vier"    };
            //int[] bb    = new int[]     { 1,        3,      2,      -4              };
            //
            //aa.Fuse(bb).OrderBy(i => i.Item2).DeFuse(out aa, out bb);
            //for (int i = 0; i < aa.Length; i++)
            //{
            //    Console.WriteLine(aa[i] + ":" + bb[i]);
            //}

            for (int counter = 0; counter < 1000; counter++)
            {
                try
                {
                    //PR_PartionLoot<string, PartitionLoot<string>> looter = new PR_PartionLoot<string, PartitionLoot<string>>(DefaultRarityTable.SharedInstance, PartitionLoot<string>.SharedInstance, checkedListBox2.CheckedItems.Cast<string>().ToArray());
                    listBox1.Items.Add(
                        GlobalItems.Instance.GetLoot(
                            PartitionLoot<string>.SharedInstance,//looter,
                            new ConfigurableFilter(
                                _nameContains: textBox1.Text,
                                _allowedTypes: checkedListBox1.CheckedItems.Cast<string>().ToArray(),
                                _allowedRarities: checkedListBox2.CheckedItems.Cast<string>().ToArray(),
                                _allowQuestItems: checkBox1.Checked
                            )
                        ).Item
                    );



                    //if (!rars.Contains(looter.LastRarity))
                    //{
                    //    rars.Add(looter.LastRarity);
                    //    rarCounts.Add(0);
                    //}
                    //rarCounts[rars.IndexOf(looter.LastRarity)]++;

                    //int j = 0;
                    //Console.WriteLine(
                    //    "(" +
                    //    counter +
                    //    ")-> " +
                    //    looter.LastRarity +
                    //    " ::rarity had probability of: " +
                    //    Math.Round(looter.LastProbability, 2) +
                    //    "% \nwith range of: " +
                    //    looter.LastRarityRange +
                    //    " \nand rarity-roll: " +
                    //    looter.LastRoll +
                    //    " /\nitem-roll: " +
                    //    looter.InnerAlgorithm.LastRoll +
                    //    " \nin total range of: [" +
                    //    looter.InnerAlgorithm.LastChain.Intervalls.First().X +
                    //    ";" +
                    //    looter.InnerAlgorithm.LastChain.Intervalls.Last().Y +
                    //    "] \nand local range of: " +
                    //    looter.InnerAlgorithm.LastIntervall +
                    //    " \nwith all items: " +
                    //    looter.InnerAlgorithm.LastItemNames.Fuse(looter.InnerAlgorithm.LastItemRarities).SumUp((f) => f.ToString(), (a, b) => a + "," + b) +
                    //    " \nor " +
                    //    string.Join(",", looter.InnerAlgorithm.LastItemNames.Select(n => "[" + n + ";" + looter.InnerAlgorithm.LastItemRarities[j++] + "]")) +
                    //    " \nor " +
                    //    string.Join(",", looter.InnerAlgorithm.LastItemNames.FuseInto(looter.InnerAlgorithm.LastItemRarities, (n, r) => "[" + n + ";" + r + "]"))
                    //    );
                }
                catch (NoMatchingLootException)
                {
                    listBox1.Items.Add("No Matching Items found");
                }
            }
            //alternativ könnte man hier zb diesen comparer verwenden
            Comparer<FusionTuple<string, int>> comparer = Comparer<FusionTuple<string, int>>.Create((f1, f2) => new RarTableOrderComperator(DefaultRarityTable.SharedInstance).Compare(f1.Item1, f2.Item1));

            Console.WriteLine("Results : " + string.Join(",", rars.Fuse(rarCounts).OrderByDescending(f => Array.IndexOf(DefaultRarityTable.SharedInstance.Values, f.Item1)).Select(f => "{" + f.Item1 + "," + f.Item2 + "}")));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalItems.Instance.AddAllLootObjects();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalItems.Instance.Remove(i => i.IsQuestItem);
        }
    }
}

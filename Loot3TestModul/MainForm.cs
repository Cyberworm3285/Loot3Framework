using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Classes.Algorithms.Filter;
using Loot3Framework.ExtensionMethods.CollectionOperations;
using Loot3Framework.Types.Classes.Algorithms.ObjectFetching;
using Loot3Framework.Global;


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
            listBox1.Items.Add(
                GlobalItems.Instance.GetLoot(
                    new PartitionLoot<string>(),
                    new ConfigurableFilter(
                        _nameContains: textBox1.Text,
                        _allowedTypes: checkedListBox1.CheckedItems.DoFunc(i => i as string),
                        _allowedRarities: checkedListBox2.CheckedItems.DoFunc(i => i as string),
                        _allowQuestItems: checkBox1.Checked
                    )
                ).Item
            );
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

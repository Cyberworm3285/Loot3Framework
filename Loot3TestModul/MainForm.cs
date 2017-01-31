using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Loot3Framework.Types.Classes.Algorithms.Looting;
using Loot3Framework.Types.Classes.Algorithms.Filter;


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
            foreach(string s in GlobalItems.Instance.AllTypeNames)
                checkedListBox1.Items.Add(s, true);
            foreach(string s in GlobalItems.Instance.AllRarityNames)
                checkedListBox2.Items.Add(s, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> aTN = new List<string>();
            List<string> aN = new List<string>();
            foreach (object s in checkedListBox1.CheckedItems) aTN.Add(s as string);
            foreach (object s in checkedListBox2.CheckedItems) aN.Add(s as string);
            listBox1.Items.Add(
                    GlobalItems.Instance.GetLoot(
                            new PartitionLoot(),
                            new ConfigurableFilter(
                                    _nameContains   : textBox1.Text,
                                    _allowedTypes   : aTN.ToArray(),
                                    _allowedRarities: aN.ToArray(),
                                    _allowQuestItems: checkBox1.Checked 
                                )
                        ).Generate()
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}

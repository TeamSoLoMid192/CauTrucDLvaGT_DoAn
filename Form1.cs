using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CTDL_EV_Dictionary_Hash
{
    public partial class Intro : Form
    {
        string filePath = "data.xml";
        public Intro()
        {
            InitializeComponent();
        }

        #region TextBox1 WaterMark
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Enter the word to find";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter the word to find")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }
        #endregion

        #region Input Search Bar
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindBt_Click(sender, e);
            }
        }

        private void FindBt_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument textXML = XDocument.Load(filePath);
                XElement cDictionaryData = textXML.Descendants("DictionaryData").Where(c => c.Attribute("ID").Value.Equals(textBox1.Text)).FirstOrDefault();
                richTextBox1.Text = cDictionaryData.Element("Key").Value + Environment.NewLine + cDictionaryData.Element("Meaning").Value + Environment.NewLine + cDictionaryData.Element("Explaination").Value;
            }
            catch
            {
                if (MessageBox.Show("The word you entered isn't exist!"+ Environment.NewLine +"Do you want to add new word? ", "Notice", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    AddWord form2 = new AddWord();
                    form2.Show();
                }
            }
        }
        #endregion

        #region FormClosing
        private void Intro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to quit ? ", "Notice", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}

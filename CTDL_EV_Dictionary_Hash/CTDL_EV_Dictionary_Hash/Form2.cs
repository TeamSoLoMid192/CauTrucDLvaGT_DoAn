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
    public partial class AddWord : Form
    {
        #region Field
        Intro form1 = new Intro();
        #endregion
        #region Constructor
        public AddWord()
        {
            InitializeComponent();
        }
        #endregion
        #region Method
        private void AddBt_Click(object sender, EventArgs e)
        {
            AddNewItem aN = new AddNewItem();
            aN.loadData(addNewKey.Text, addMeaningBox.Text);
            if (MessageBox.Show("Thank you!" + Environment.NewLine + "Your word will be updated next time.", "Notice", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion
    }
}

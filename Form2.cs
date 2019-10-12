using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTDL_EV_Dictionary_Hash
{
    public partial class AddWord : Form
    {
        public AddWord()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddBt_Click(sender, e);
            }
        }

        private void AddBt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thank you!", "Notice", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
            // chưa xong, cần lưu dữ liệu đc add
        }
    }
}

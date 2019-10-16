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
        AddNewItem addNew = new AddNewItem();
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
            textBox1.Text = textBox1.Text.ToLower(); // chuyển từ nhập vào Search Bar thành chữ thường
            AddWord form2 = new AddWord();
            form2.addNewKey.Text = textBox1.Text;   // Sao chép chuỗi ở Search Bar vào thanh Add new key
            try    // nếu OK: thì đọc và load dữ liệu lên bình thường
            {
                XDocument textXML = XDocument.Load(DictionaryManager.filePath); // tạo mới đối tượng danh sách data và load từ file
                XElement cDictionaryData = textXML.Descendants("DictionaryData").Where(c => c.Attribute("ID").Value.Equals(Convert.ToString(addNew.getHashCode(textBox1.Text)))).FirstOrDefault(); // tạo mới đối tượng là gói dữ liệu của 1 từ đồng thời trỏ đến địa chỉ (ID) lưu gói từ đó
                richTextBox1.Text = cDictionaryData.Element("Key").Value + Environment.NewLine + cDictionaryData.Element("Meaning").Value; // đưa dữ liệu nghĩa của từ vào ô Meaning and Explaination
                // sẽ xử lí tìm kiếm trùng lặp tại đây
            }
            catch  // lỗi: tức chưa có từ này trong dữ liệu, đề nghị đóng góp từ mới vào dữ liệu
            {
                if (MessageBox.Show("The word you entered isn't exist!"+ Environment.NewLine +"Do you want to add new word? ", "Notice", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)   //hỏi có muốn add từ mới này không?, nếu có thì làm trong {} sau
                {
                    form2.Show();   // mở form2 để add từ mới
                    form2.addMeaningBox.Focus();    // đặt con trỏ soạn thảo mặc định vào ô Meaning and Explaination của form2 (add từ mới)
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

        private void Intro_Load(object sender, EventArgs e)
        {
            //để tạm, sẽ làm load data from dataF1.xml vào data.xml
        }

        private void LoadDataBT_Click(object sender, EventArgs e)
        {
            DictionaryManager dicMan = new DictionaryManager();

            //AddNewItem addNew = new AddNewItem();
            //DictionaryItem
            foreach (DictionaryData dicDataTemp in dicMan.Items.Items)
            {
                addNew.loadData(dicDataTemp.Key, dicDataTemp.Meaning);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CTDL_EV_Dictionary_Hash
{
    public partial class Intro : Form
    {
        #region Field
        AddNewItem addNew = new AddNewItem();
        private string searchBarHashKey;
        Pronounce speakEng;

        public string SearchBarHashKey { get => searchBarHashKey; set => searchBarHashKey = value; }
        #endregion
        #region Constructor
        public Intro()
        {
            InitializeComponent();

            WebBrowser Batman = new WebBrowser();
            Batman.Width = 0;
            Batman.Height = 0;
            Batman.Visible = false;
            Batman.ScriptErrorsSuppressed = true;
            speakEng = new Pronounce(Batman);
            Batman.Navigate(speakEng.engAPILink);
        }
        #endregion

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

            SearchBarHashKey = Convert.ToString(addNew.getHashCode(textBox1.Text));

            form2.addNewKey.Text = textBox1.Text;   // Sao chép chuỗi ở Search Bar vào thanh Add new key
            try    // nếu OK: thì đọc và load dữ liệu lên bình thường
            {
                XDocument textXML = XDocument.Load(DictionaryManager.filePath); // tạo mới đối tượng danh sách data và load từ file
                XElement cDictionaryData = textXML.Descendants("DictionaryData").Where(c => c.Attribute("ID").Value.Equals(SearchBarHashKey)).FirstOrDefault(); // tạo mới đối tượng là gói dữ liệu của 1 từ đồng thời trỏ đến địa chỉ (ID) lưu gói từ đó
                
                if (textBox1.Text == cDictionaryData.Element("Key").Value)
                {
                    richTextBox1.Text = cDictionaryData.Element("Key").Value + Environment.NewLine + cDictionaryData.Element("Meaning").Value; // đưa dữ liệu nghĩa của từ vào ô Meaning and Explaination
                }
                else
                {
                    foreach(XElement cc in cDictionaryData.Descendants("SubDictionaryData"))
                    {
                        if(textBox1.Text == cc.Element("Key").Value)
                        {
                            richTextBox1.Text = cc.Element("Key").Value + Environment.NewLine + cc.Element("Meaning").Value;
                            break;
                        }
                    }
                }
            }
            catch  // lỗi: tức chưa có từ này trong dữ liệu, đề nghị đóng góp từ mới vào dữ liệu
            {
                if (MessageBox.Show("The word you entered doesn't exist!" + Environment.NewLine + "Do you want to add new word? ", "Notice", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)   //hỏi có muốn add từ mới này không?, nếu có thì làm trong {} sau
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
        #region Load Data To Hash Table
        private void LoadDataBT_Click(object sender, EventArgs e)
        {
            //DictionaryManager dicMan = new DictionaryManager();

            //foreach (DictionaryData dicDataTemp in dicMan.Items.Items)
            //{
            //    addNew.loadData(dicDataTemp.Key, dicDataTemp.Meaning);
            //}
            if(MessageBox.Show("Are you sure load or reload new data to Dictionary","Notice",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Thread loadDT = new Thread(LoadDataToHashTB);
                loadDT.Start();
            } 
        }

        void LoadDataToHashTB()
        {
            DictionaryManager dicMan = new DictionaryManager();

            foreach (DictionaryData dicDataTemp in dicMan.Items.Items)
            {
                addNew.loadData(dicDataTemp.Key, dicDataTemp.Meaning);
            }
        }
        #endregion
        #region Pronounce Word
        private void SpeakBt_Click(object sender, EventArgs e)
        {
            speakEng.Speak(textBox1.Text);
        }
        #endregion
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Linq;

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
    public class AddNewItem
    {
        #region Methods
        public long getHashCode(string S)
        {
            GeneralHashFunctionLibrary rr = new GeneralHashFunctionLibrary();
            long getID = rr.PJWHash(S);
            return getID;
        }
        public void loadData(string keyStr, string meaningStr)
        {
            string idTemp = Convert.ToString(getHashCode(keyStr));

            XDocument data = XDocument.Load(DictionaryManager.filePath);

            XElement findEl = data.Descendants("DictionaryData").Where(c => c.Attribute("ID").Value.Equals(idTemp)).FirstOrDefault();

            try
            {
                if (idTemp == findEl.Attribute("ID").Value)
                {
                    if (keyStr != findEl.Element("Key").Value)
                    {
                        try
                        {
                            bool flag = true;
                            foreach (XElement cc in findEl.Descendants("SubDictionaryData"))
                            {
                                if (keyStr == cc.Element("Key").Value)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                XElement subDictionaryData = new XElement("SubDictionaryData", new XElement("Key", keyStr), new XElement("Meaning", meaningStr));

                                findEl.Add(subDictionaryData);

                                data.Save(DictionaryManager.filePath);
                            }
                        }
                        catch
                        {
                            XElement subDictionaryData = new XElement("SubDictionaryData", new XElement("Key", keyStr), new XElement("Meaning", meaningStr));

                            findEl.Add(subDictionaryData);

                            data.Save(DictionaryManager.filePath);
                        }
                    }
                }
            }
            catch
            {
                XElement newDictionaryData = new XElement("DictionaryData", new XElement("Key", keyStr), new XElement("Meaning", meaningStr));
                //var newLastWord = data.Descendants("DictionaryData").Last();

                long getID = getHashCode(keyStr);//lấy mã băm
                newDictionaryData.SetAttributeValue("ID", Convert.ToString(getID));

                data.Element("Items").Add(newDictionaryData);
                data.Save(DictionaryManager.filePath);
            }
        }
        #endregion
    }
}

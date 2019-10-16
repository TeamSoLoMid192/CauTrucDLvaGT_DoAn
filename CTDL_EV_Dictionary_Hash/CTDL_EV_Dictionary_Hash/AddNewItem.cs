using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CTDL_EV_Dictionary_Hash
{
    public class AddNewItem
    {
        //public static string filePath = "data.xml";
        //public string dataFileName = "dataF1.xml";
        public long getHashCode(string S)
        {
            GeneralHashFunctionLibrary rr = new GeneralHashFunctionLibrary();
            long getID = rr.PJWHash(S);
            return getID;
        }
        public void loadData(string keyStr, string meaningStr)
        {
            XDocument data = XDocument.Load(DictionaryManager.filePath);
            XElement newDictionaryData = new XElement("DictionaryData", new XElement("Key",keyStr), new XElement("Meaning",meaningStr));
            var newLastWord = data.Descendants("DictionaryData").Last();

            long getID = getHashCode(keyStr);//lấy mã băm
            newDictionaryData.SetAttributeValue("ID", Convert.ToString(getID));

            data.Element("Items").Add(newDictionaryData);
            data.Save(DictionaryManager.filePath);
        }
    }
}

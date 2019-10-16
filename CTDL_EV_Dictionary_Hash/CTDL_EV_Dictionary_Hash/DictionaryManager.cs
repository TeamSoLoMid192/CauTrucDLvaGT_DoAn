using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace CTDL_EV_Dictionary_Hash
{
    public class DictionaryManager
    {
        #region property
        public static string dataFileName = "dataF1.xml";
        public static string filePath = "data.xml";

        private DictionaryItem items;

        public DictionaryItem Items { get => items; set => items = value; }
        #endregion

        #region method
        public DictionaryManager()
        {
            items = (DictionaryItem)DeserializeFromXml(dataFileName);
        }

        //public void LoadDataToSearchBox(ComboBox tBox)
        //{
        //    tBox.DataSource = items.Items;
        //}

        //public void SerializeToXml(object data, string dataFileName)
        //{

        //}

        public object DeserializeFromXml(string dataFileName)
        {
            FileStream fs = new FileStream(dataFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            XmlSerializer xs = new XmlSerializer(typeof(DictionaryItem));

            object obj = xs.Deserialize(fs);

            return obj;
        }
        #endregion
    }
}

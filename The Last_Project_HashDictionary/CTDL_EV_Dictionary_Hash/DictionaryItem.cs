using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDL_EV_Dictionary_Hash
{
    [Serializable]
    public class DictionaryItem
    {
        private List<DictionaryData> items;

        public List<DictionaryData> Items { get => items; set => items = value; }
    }
}

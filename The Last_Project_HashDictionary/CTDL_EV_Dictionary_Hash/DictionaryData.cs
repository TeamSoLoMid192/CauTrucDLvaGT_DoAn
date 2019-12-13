using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDL_EV_Dictionary_Hash
{
    public class DictionaryData
    {
        private string key;

        public string Key { get => key; set => key = value; }

        private string meaning;

        public string Meaning { get => meaning; set => meaning = value; }
    }
}

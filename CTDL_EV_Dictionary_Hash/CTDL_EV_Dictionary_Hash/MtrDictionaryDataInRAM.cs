using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDL_EV_Dictionary_Hash
{
    class MtrDictionaryDataInRAM
    {
        string Key;
        string Meaning;
        List<CollisionDictionaryData> hashCollisionList;

        public string Key1 { get => Key; set => Key = value; }
        public string Meaning1 { get => Meaning; set => Meaning = value; }
        internal List<CollisionDictionaryData> HashCollisionList { get => hashCollisionList; set => hashCollisionList = value; }
    }
}

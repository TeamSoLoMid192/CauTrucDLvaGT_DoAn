using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTDL_EV_Dictionary_Hash
{
    class GeneralHashFunctionLibrary
    {

        public long RSHash(String str)
        {
            int b = 378551;
            int a = 63689;
            long hash = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = hash * a + str[i];
                a = a * b;
            }

            return hash;
        }
        /* End Of RS Hash Function */


        public long JSHash(String str)
        {
            long hash = 1315423911;

            for (int i = 0; i < str.Length; i++)
            {
                hash ^= ((hash << 5) + str[i] + (hash >> 2));
            }

            return hash;
        }
        /* End Of JS Hash Function */


        public long PJWHash(String str)
        {
            int BitsInUnsignedInt = 4 * 8; // số bit trong kiểu dữ liệu unsigned int
            int ThreeQuarters = ((BitsInUnsignedInt * 3) / 4);
            int OneEighth = (BitsInUnsignedInt / 8);
            long HighBits = (long)(0xFFFFFFFF) << (BitsInUnsignedInt - OneEighth);
            long hash = 0;
            long test = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = (hash << OneEighth) + str[i];

                if ((test = hash & HighBits) != 0)
                {
                    hash = ((hash ^ (test >> ThreeQuarters)) & (~HighBits));
                }
            }
            //MessageBox.Show(Convert.ToString(hash));
            return hash;
        }
        /* End Of  P. J. Weinberger Hash Function */


        public long ELFHash(String str)
        {
            long hash = 0;
            long x = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = (hash << 4) + str[i];

                if ((x = hash & 0xF0000000L) != 0)
                {
                    hash ^= (x >> 24);
                }
                hash &= ~x;
            }

            return hash;
        }
        /* End Of ELF Hash Function */


        public long BKDRHash(String str)
        {
            long seed = 131; // 31 131 1313 13131 131313 etc..
            long hash = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = (hash * seed) + str[i];
            }

            return hash;
        }
        /* End Of BKDR Hash Function */


        public long SDBMHash(String str)
        {
            long hash = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = str[i] + (hash << 6) + (hash << 16) - hash;
            }

            return hash;
        }
        /* End Of SDBM Hash Function */


        public long DJBHash(String str)
        {
            long hash = 5381;

            for (int i = 0; i < str.Length; i++)
            {
                hash = ((hash << 5) + hash) + str[i];
            }

            return hash;
        }
        /* End Of DJB Hash Function */


        public long DEKHash(String str)
        {
            long hash = str.Length;

            for (int i = 0; i < str.Length; i++)
            {
                hash = ((hash << 5) ^ (hash >> 27)) ^ str[i];
            }

            return hash;
        }
        /* End Of DEK Hash Function */


        public long BPHash(String str)
        {
            long hash = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = hash << 7 ^ str[i];
            }

            return hash;
        }
        /* End Of BP Hash Function */


        public long FNVHash(String str)
        {
            long fnv_prime = 0x811C9DC5;
            long hash = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash *= fnv_prime;
                hash ^= str[i];
            }

            return hash;
        }
        /* End Of FNV Hash Function */


        public long APHash(String str)
        {
            long hash = 0xAAAAAAAA;

            for (int i = 0; i < str.Length; i++)
            {
                if ((i & 1) == 0)
                {
                    hash ^= ((hash << 7) ^ str[i] * (hash >> 3));
                }
                else
                {
                    hash ^= (~((hash << 11) + str[i] ^ (hash >> 5)));
                }
            }

            return hash;
        }
        /* End Of AP Hash Function */
    }
}

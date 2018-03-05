using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KriptoLaba1
{
    class TableTrans : BasicDictionaryClass
    {
        private int[] key = null;

        public void SetKey(string _key)
        {
            _key = _key.ToUpper();
            char[] char_key = _key.ToCharArray();
            key = new int[char_key.Length];

            for (int i = 0; i < char_key.Length; i++)
            {
                key[i] = alphabet[char_key[i]];
            }
        }

        public string Encrypt(string input)
        {
            for (int i = 0; i < input.Length % key.Length; i++)
                input += input[i];

            string result = "";

            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[key[j] - 1] = input[i + j];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }

            return result;
        }

        public string Decrypt(string input)
        {
            string result = "";

            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[j] = input[i + key[j] - 1];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }

            return result;
        }
    }
}

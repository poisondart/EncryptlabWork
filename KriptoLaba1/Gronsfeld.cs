using System;
using System.Collections.Generic;
using System.Text;

namespace Gronsfeld
{
    public class Gronsfeld
    {
        private static string RusAlphabet = " абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string EncryptionGronsfeld(string key,string text)
        {
            text = text.ToLower();
            string ciphertext = null;
            string fullKey = СreateFullKey(key, text);
            for (int i = 0; i < text.Length; i++)
            {
                for(int j = 0;j < RusAlphabet.Length;j++)
                {
                   if(text[i] == RusAlphabet[j])
                    {
                        var offset = j + Convert.ToInt32(fullKey[i]) - 48;
                        offset = CalculationOffset(offset);
                        ciphertext += Convert.ToString(RusAlphabet[offset]);
                    }
                }
             
            }
            return ciphertext;
        }

        private static string СreateFullKey(string key, string inputText)
        {
            while (key.Length < inputText.Length)
            {
                key += key;
            }
            if (key.Length > inputText.Length)
            {
                key = key.Substring(0, key.Length - (key.Length - inputText.Length));
            }
            return key;
        }

        private static int CalculationOffset(int iputOffset)
        {
            while (iputOffset >= RusAlphabet.Length)
            {
                iputOffset = iputOffset - RusAlphabet.Length;
            }
            return iputOffset;
        }

        public static string Decryption(string key, string text)
        {
            text = text.ToLower();
            string decipheredText = null;
            string fullKey = СreateFullKey(key, text);
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < RusAlphabet.Length; j++)
                {
                    if (text[i] == RusAlphabet[j])
                    {
                        var offset = j - Convert.ToInt32(fullKey[i]) + 48;
                        offset = CalculationOffset(offset);
                        decipheredText += Convert.ToString(RusAlphabet[offset]);
                    }
                }

            }
            return decipheredText;
        }
    }
}

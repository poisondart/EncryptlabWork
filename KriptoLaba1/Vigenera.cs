using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenera
{
    public class Vigenera
    {
        private static string RusAlphabet = " абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string EncryptionGronsfeld(string key, string inputText)
        {
            inputText = inputText.ToLower();
            key = key.ToLower();
            string ciphertext = null;
            string fullKey = СreateFullKey(key, inputText);
            int keyIndex = 0;
            foreach (char symbol in inputText)
            {
                var a = RusAlphabet.IndexOf(symbol);
                var b = RusAlphabet.IndexOf(key[keyIndex]);
                int indexLetter = (RusAlphabet.IndexOf(symbol) + RusAlphabet.IndexOf(key[keyIndex])) % RusAlphabet.Length;
                ciphertext += RusAlphabet[indexLetter];
                keyIndex++;
                if ((keyIndex + 1) == key.Length)
                    keyIndex = 0;
            }

            return ciphertext;
        }

        public static string Decryption(string key, string inputText)
        {
            inputText = inputText.ToLower();
            key = key.ToLower();
            string decipheredText = null;
            string fullKey = СreateFullKey(key, inputText);
            int keyIndex = 0;
            foreach (char symbol in inputText)
            {
                int indexLetter = (RusAlphabet.IndexOf(symbol)+ RusAlphabet.Length - RusAlphabet.IndexOf(key[keyIndex])) % RusAlphabet.Length;
                decipheredText += RusAlphabet[indexLetter];
                keyIndex++;
                if ((keyIndex + 1) == key.Length)
                    keyIndex = 0;
            }
            return decipheredText;
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
    }
}

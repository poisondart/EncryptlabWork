using System;
using System.Collections.Generic;
using System.Text;

namespace KriptoLaba1
{
    public class MagicSquare
    {
        public int[,] defaultSquare = new int[4, 4] { { 16, 3, 2, 13 }, { 9, 6, 7, 12 }, { 5, 10, 11, 8 }, { 4, 15, 14, 1 } };

        public char[,] EncryptionMagicSquare(string text)
        {
            int index = 0;
            char[,] encryptedText = new char[4, 4] { { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' }, { ' ', ' ', ' ', ' ' } };
            while (index != text.Length)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((defaultSquare[i, j] == index + 1) && (index != text.Length))
                        {
                            encryptedText[i, j] = text[index];
                            index++;
                        }
                    }
                }

            }

            return encryptedText;
        }

        public string DecipherMagicSquare(char[,] text)
        {
            int index = 0;
            string decipheredText = null;
            while (index != text.Length)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((defaultSquare[i, j] == index + 1) && (index != text.Length))
                        {
                            decipheredText += Convert.ToString(text[i, j]);
                            index++;
                        }
                    }
                }
            }
            return decipheredText;
        }
    }
}

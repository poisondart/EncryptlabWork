using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KriptoLaba1
{
    class WheatStone
    {
        private char[,] first_matrix = new char[7, 5]
        { 
          {'ж', 'щ', 'н', 'ю', 'р'}, 
          {'и', 'т', 'ь', 'ц', 'б'},
          {'я', 'м', 'е', '.', 'с'},
          {'в', 'ы', 'п', 'ч', ' '},
          {'й', 'д', 'у', 'о', 'к'},
          {'з', 'э', 'ф', 'г', 'ш'},
          {'х', 'а', ',', 'л', 'ъ'}
        };

        private char[,] second_matrix = new char[7, 5]
        {
          {'и', 'ч', 'г', 'я', 'т'},
          {',', 'ж', 'м', 'ь', 'о'},
          {'з', 'ю', 'р', 'в', 'щ'},
          {'ц', 'й', 'п', 'е', 'л'},
          {'ъ', 'а', 'н', '.', 'х'},
          {'э', 'к', 'с', 'ш', 'д'},
          {'б', 'ф', 'у', 'ы', ' '}
        };

        public string Encrypt(string text)
        {
            text = text.ToLower();

            string result_text = "";

            if (text.Length % 2 != 0)
            {
                text += ' ';
            }
            int length = text.Length / 2;
            int k = 0;
            char[,] bigram = new char[length, 2];
            char[,] kripto_bigram = new char[length, 2];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bigram[i, j] = text[k];
                    k++;
                }
            }
            int step = 0;
            while (step < length)
            {
                Cortege cortege1 = FindIndexes(bigram[step,0], first_matrix);
                Cortege cortege2 = FindIndexes(bigram[step, 1], second_matrix);

                kripto_bigram[step, 0] = second_matrix[cortege1.I, cortege2.J];
                kripto_bigram[step, 1] = first_matrix[cortege2.I, cortege1.J];

                step++;
            }


            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result_text += kripto_bigram[i, j].ToString();
                }
            }

            return result_text;
        }


        public string Decrypt(string text)
        {
            string result_text = "";

            int length = text.Length / 2;
            int k = 0;

            char[,] bigram = new char[length, 2];
            char[,] kripto_bigram = new char[length, 2];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bigram[i, j] = text[k];
                    k++;
                }
            }

            int step = 0;
            while (step < length)
            {
                Cortege cortege1 = FindIndexes(bigram[step, 0], second_matrix);
                Cortege cortege2 = FindIndexes(bigram[step, 1], first_matrix);

                kripto_bigram[step, 0] = first_matrix[cortege1.I, cortege2.J];
                kripto_bigram[step, 1] = second_matrix[cortege2.I, cortege1.J];

                step++;
            }


            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result_text += kripto_bigram[i, j].ToString();
                }
            }


            return result_text;
        }

        private Cortege FindIndexes(char symbol, char[,] matrix)
        {
            Cortege cortege = new Cortege();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (symbol == matrix[i, j])
                    {
                        cortege.I = i;
                        cortege.J = j;
                        return cortege;
                    }
                }
            }

            return null;
        }

        private class Cortege
        {
            public int I { get; set; }
            public int J { get; set; }
            public Cortege() { }
        }
    }
}
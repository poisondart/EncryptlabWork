using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* описание алгоритма
 https://ru.bmstu.wiki/%D0%A8%D0%B8%D1%84%D1%80_%D0%A1%D1%86%D0%B8%D1%82%D0%B0%D0%BB%D0%B0
*/

namespace KriptoLaba1
{
    class Skital
    {
        //длина шифрующей палочки(сколько столбцов в таблице) и количество строк в таблице
        private int diameter_word_length = 0, lines = 0;
        //устанавливаем длину
        public void SetLength(string l)
        {
            diameter_word_length = Convert.ToInt32(l);
        }

        public string EncryptText(string s)
        {
            //считаем количество строк
            lines = (s.Length - 1) / diameter_word_length + 1;
            //считаем количество незаполненных ячеек и заполняем пробелами в цикле
            int spaces = lines * diameter_word_length - s.Length;
            for (int l = 0; l < spaces; l++)
                s += " ";
            //создаём буферную матрицу, в которую положим ответ с помощью цикла
            string[,] buffer_array = new string[diameter_word_length, lines];
            //ответ
            string result_text = "";
            int k = 0;
            //заполняем матрицу посимвольно, символы слов записываются в столбики
            for (int i = 0; i < diameter_word_length; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    buffer_array[i, j] = s.Substring(k, 1);
                    k += 1;
                }
            }
            //переводим матрицу в фразу
            for (int j1 = 0; j1 < lines; j1++)
            {
                for (int i1 = 0; i1 < diameter_word_length; i1++)
                    result_text += buffer_array[i1, j1];
            }
            return result_text;
        }

        public string DecryptText(string s)
        {
            //считаем количество строк
            lines = (s.Length - 1) / diameter_word_length + 1;
            //считаем количество незаполненных ячеек и заполняем пробелами в цикле
            int spaces = lines * diameter_word_length - s.Length;
            for (int l = 0; l < spaces; l++)
                s += " ";
            //заполняем создаём буферную матрицу, в которую положим ответ с помощью цикла
            string[,] buffer_array = new string[diameter_word_length, lines];
            //ответ
            string result_text = "";
            int k = 0;
            //заполняем матрицу посимвольно, символы слов из столбиков записываются в строки
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < diameter_word_length; j++)
                {
                    buffer_array[j, i] = s.Substring(k, 1);
                    k += 1;
                }
            }
            //переводим матрицу в фразу
            for (int j1 = 0; j1 < diameter_word_length; j1++)
            {
                for (int i1 = 0; i1 < lines; i1++)
                    result_text += buffer_array[j1, i1];
            }
            return result_text;
        }
    }
}

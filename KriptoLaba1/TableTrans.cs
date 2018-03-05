using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* основной алгоритм
 http://vscode.ru/prog-lessons/shifr-perestanovki.html
*/

namespace KriptoLaba1
{
    class TableTrans: BaseTrans
    {
        // ключ в виде массива номеров символов
        private int[] key = null;

        public void SetKey(string _key)
        {
            // переводим строку в ВЕРХНИЙ регистр, потому что символы в нашем алфавите в ВЕРХНЕМ регистре
            _key = _key.ToUpper();
            char[] char_key = _key.ToCharArray();
            // получаем массив с цифрами длиной равной массиву с символов
            int[] result_key = new int[char_key.Length];
            // копия result_key
            int[] buffer_key = new int[char_key.Length];
            /*заполняем массивы номерами символов ключа по алфавиту, то есть, 
            например, буква "Д" 5ая в алфавите, значит заносим 5 в массив*/
            for (int i = 0; i < char_key.Length; i++)
            {
                result_key[i] = alphabet[char_key[i]]; 
                buffer_key[i] = alphabet[char_key[i]];   
            }
            //сортируем буфферный ключ по возрастанию
            Array.Sort(buffer_key);
            /*
             тут самое интересное)) мы не можем непосредсвенно записать в ключ номер элемента
             в алфавите - он может быть слишком большим (буква "х" 23 например). мы можем можем лишь написать номер 
             символа относительно остальных в ключе, тоесть самый близкий к началу алфавита будет первым, 
             самый близкий к концу - последним, равным длине ключа. остальные символы распределяются между ними в зависимости 
             от позиции в алфавите.
             */
            for (int i = 0; i < result_key.Length; i++)
            {
                int value = result_key[i];
                result_key[i] = Array.IndexOf(buffer_key, value) + 1;
            }

            key = result_key;
        }

        public string Encrypt(string input)
        {
            /*если длина фразы делится на длину ключа с остатком, то добавляем пробелы в фразу,
            пока не будет делиться без остатка*/
            for (int i = 0; i < input.Length % key.Length; i++)
                input += ' ';

            string result = "";
            //непосредственно цикл перестановки
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
            //почти аналогично шифрованию
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

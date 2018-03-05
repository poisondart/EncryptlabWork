using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KriptoLaba1
{
    class DoubleTrans : BaseTrans
    {
        private int[] cryptKeyOne; // Первый ключ(столбцы)
        private int[] cryptKeyTwo; // Второй ключ(строки)
        string originalStr; // исходнная срока

        public DoubleTrans(string _originalstr, string _kriptkeyone, string _kriptkeytwo)
        {
            try
            {

                if (_kriptkeyone.Length != _kriptkeytwo.Length) throw new Exception("Keys is not equal");

                if (_kriptkeyone.Length * _kriptkeytwo.Length < _originalstr.Length) throw new Exception("String is biger of table size");

                if (CheckRepeat(_kriptkeyone) | CheckRepeat(_kriptkeytwo)) throw new Exception("The key contains duplicates");

                /***********
                преобразуем ключи-сторки в массив порядковых 
                номеров литералов в алфавите
                ***********/
                cryptKeyOne = StringToArrayNumberPos(_kriptkeyone);
                cryptKeyTwo = StringToArrayNumberPos(_kriptkeytwo);

            }
            catch (Exception ex) { throw ex; }


            originalStr = _originalstr;
        }

        public string EncryptDecrypt()
        {

            /**********
            сортируем численые ключи-массивы по возрастанию
            **********/
            int[] assortKeyOne = cryptKeyOne.OrderBy(x => x).ToArray();
            int[] assortKeyTwo = cryptKeyTwo.OrderBy(x => x).ToArray();


            char[,] encryptStr = new char[assortKeyOne.Length, assortKeyTwo.Length]; // зашифрованная строка
            char[,] originalStrArray = new char[assortKeyOne.Length, assortKeyTwo.Length]; // массив элементов шифруемой строки(шифруемая строка)

            // преобразуем шифруемую строку в массив
            int count = 0;
            for (int i = 0; i < assortKeyOne.Length; i++)
                for (int j = 0; j < assortKeyTwo.Length; j++)
                {

                    originalStrArray[i, j] = originalStr.ToString().Length <= count ? ' ' : originalStr[count];
                    count++;
                }

            // шифрование
            for (int i = 0; i < assortKeyOne.Length; i++)
                for (int j = 0; j < assortKeyTwo.Length; j++)
                {
                    /***********************
                     берем номер нужной нам строки/столбца и ищем его индекс в несортированном ключе
                     полученые индексы строки и стобца будут позицией элмента 
                     необходимого для записи в зашифрованную строку
                    ***********************/
                    int rownumber = Array.IndexOf(cryptKeyTwo, assortKeyTwo[i]);
                    int columnumber = Array.IndexOf(cryptKeyOne, assortKeyOne[j]);

                    encryptStr[i, j] = originalStrArray[rownumber, columnumber]; //
                }

            StringBuilder rezultStr = new StringBuilder(assortKeyOne.Length * assortKeyTwo.Length);
            for (int i = 0; i < assortKeyOne.Length; i++)
                for (int j = 0; j < assortKeyTwo.Length; j++)
                {

                    rezultStr.Append(encryptStr[i, j]);
                }

            return rezultStr.ToString();
        }
    }
}

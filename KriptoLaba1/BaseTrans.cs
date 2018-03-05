using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KriptoLaba1
{
    class BaseTrans
    {
        protected Dictionary<char, int> alphabet = new Dictionary<char, int>
        {
                    { 'А', 1 },
                    { 'Б', 2 },
                    { 'В', 3 },
                    { 'Г', 4 },
                    { 'Д', 5 },
                    { 'Е', 6 },
                    { 'Ё', 7 },
                    { 'Ж', 8 },
                    { 'З', 9 },
                    { 'И', 10 },
                    { 'Й', 11 },
                    { 'К', 12 },
                    { 'Л', 13 },
                    { 'М', 14 },
                    { 'Н', 15 },
                    { 'О', 16 },
                    { 'П', 17 },
                    { 'Р', 18 },
                    { 'С', 19 },
                    { 'Т', 20 },
                    { 'У', 21 },
                    { 'Ф', 22 },
                    { 'Х', 23 },
                    { 'Ц', 24 },
                    { 'Ч', 25 },
                    { 'Ш', 26 },
                    { 'Щ', 27 },
                    { 'Ъ', 28 },
                    { 'Ы', 29 },
                    { 'Ь', 30 },
                    { 'Э', 31 },
                    { 'Ю', 32 },
                    { 'Я', 33 }
        };

        /// <summary>
        /// Метод StringToArrayNumberPos(string _stringchar) преобразует 
        /// строку в массив позиций ее литералов в алфавите
        /// </summary>
        protected int[] StringToArrayNumberPos(string _stringchar)
        {

            int[] resarray = new int[_stringchar.Length];
            uint count = 0;
            try
            {
                foreach (char literal in _stringchar.ToUpperInvariant())
                    resarray[count++] = alphabet[literal];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resarray;
        }

        /// <summary>
        /// Метод CheckRepeat(string _checkedstr) проверяет строку на повторы элементов
        /// </summary>
        protected bool CheckRepeat(string _checkedstr)
        {
            uint count = 0;
            foreach (char later in _checkedstr)
            {
                count = (uint)_checkedstr.Where(x => x == later).Count();
                if (count > 1) return true;
            }

            return false;
        }
    }
}

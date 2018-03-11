namespace KriptoLaba1
{
    public class Ceasar
    {
        private string _text;
        private readonly int _key;

        public Ceasar(string text, int key)
        {
            _text = text;
            _key = key;
        }
        
        public string GetText => _text;

        public void Encode()
        {
            var encodedText = "";

            foreach (var character in _text)
            {
                if (character!=' ')
                {
//                  смотрим заглавные буквы или строчные 
                    if (character>1071)
                    {
//                      получаем код символа, смещаем его и переводим обратно в символ
                        encodedText += (char)((character - 1072 + _key) % 32 + 1072);
                    }
                    else
                    {
//                      аналогично для заглавных
                        encodedText += (char)((character - 1040 + _key) % 32 + 1040);
                    }
                }
                else
                {
                    encodedText += ' ';
                }
               
            }
                
            _text = encodedText;
        }

//        для декодирования мы, по сути, переворачиваем алфавит и делаем тоже самое, что и при кодировке
        public void Decode()
        {
            var decodedText = "";

            foreach (var character in _text)
            {
                if (character != ' ')
                {
                    if (character>1071)
                    {
                        decodedText += (char)(1103 - (1103 - character + _key) % 32);
                    }
                    else
                    {
                        decodedText += (char)(1071 - (1071 - character + _key) % 32);
                    }
                }
                else
                {
                    decodedText += ' ';
                }

            }
            _text = decodedText;
        }

    }
}
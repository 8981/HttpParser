using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace HttpParser
{
    class ParserUnicWords
    {
        public void GetUnicWords(string url)
        {
            WebClient client = new WebClient();

            // Получаем содержимое страницы
            string data;
            using (Stream stream = client.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();   
                }
            }

               //Парсим теги
               Regex regex = new Regex(@"<a.*?>(.*?)</a>");
               MatchCollection matches = regex.Matches(data);

               List<string> words = new List<string>();

               foreach(Match m in matches)
               {

                   words.Add(m.Groups[1].Value);

               }

               foreach(string word in words)
                {
                    Console.WriteLine(word);

                }
               
        }
    }
}

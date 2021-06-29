using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HttpParser
{
    class CalcUniqWords
    {
        ///<summary>
        ///Unique words and quantity
        ///</summary>
        public string[] page { get; private set;} 

        public CalcUniqWords(string[] pages)
        {
            page = pages;
        }

        public void Pars()
        {
            for(int i = 0; i < page.Length; i++)
            {
                Console.WriteLine("Words of - " + page[i]);
                Console.WriteLine("============================================");
                string text = ReadTextFromPage(page[i]);

                if(text == null)
                {
                    Console.WriteLine("Wrong respond from page");
                    break;
                }
                var result = Calculate(text);
                result.Remove("");
                foreach (var pair in result)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                Console.WriteLine("============================================");
            }
        }

        static Dictionary<string, int> Calculate(string page)
        {
            var result = new Dictionary<string, int>();
            foreach (var word in page.Split(' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1))
            {
                var count = 0;
                result.TryGetValue(word, out count);
                result[word] = count + 1;
            }

            return result;
        }

        public string ReadTextFromPage(string page)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                HtmlDocument document = htmlWeb.Load(page);
                return document.DocumentNode.InnerText;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
                return null;
            }
        }
    }
}

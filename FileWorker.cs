using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpParser
{
    class FileWorker
    {
        ///<summary>
        ///Red file page.txt
        ///</summary>
        ///<remarks>
        ///This class generate fole and check data
        ///</remarks>
        public string[] ReadFile()
        {
            string[] readText;
            string[] templateReadText;

            //Get the current directory
            string directory = Directory.GetCurrentDirectory();
            string page = "page.txt";
            string path = directory + @"\" + page;
            
            if(!File.Exists(path))
            {
                Console.WriteLine("File pages not exist");
                string[] createText = { "https://www.simbirsoft.com/" };
                File.WriteAllLines(path, createText);
            }

            templateReadText = File.ReadAllLines(path);
            readText = CheckUrl(templateReadText);
            if(readText == null)
            {
                Environment.Exit(-1);
            }
            return readText;
        }

        string[] CheckUrl(string[] checkUrl)
        {
            List<string> templateReadTextCheck = new List<string>();
            string pattern = @"^(http|http(s)?://)+([\w-]+\.)+(\[\?%&=]*)?";
            for(int i = 0; i < checkUrl.Length; i++)
            {
                if(Regex.IsMatch(checkUrl[i], pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("url aplay");
                    templateReadTextCheck.Add(checkUrl[i]);
                }
                else
                {
                    Console.WriteLine("Incorrect url");
                    Console.WriteLine("Строка {0}", checkUrl[i]);
                }
            }
            return templateReadTextCheck.ToArray();
        }
    }
}

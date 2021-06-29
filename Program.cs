using HttpParser;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace HttpParser
{
    class Program
    {
        public static void Main()
        {
            Program program = new Program();
            program.Start();
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
            
        }

        public void Start() 
        {
            FileWorker fileWorker = new FileWorker();
            HTMLSaver htmlSaver;
            CalcUniqWords calcUniqWords;
            var urldata = fileWorker.ReadFile();
            Console.WriteLine(urldata);
            htmlSaver = new HTMLSaver(urldata);
            htmlSaver.SaveHTMLPage();
            calcUniqWords = new CalcUniqWords(urldata);
            calcUniqWords.Pars();


        }

        
    }
}
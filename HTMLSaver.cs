using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpParser
{
    class HTMLSaver
    {
        ///<summary>
        ///Save site page
        ///</summary>
       
        public string[] page { get; private set; }

        public HTMLSaver (string[] pages)
        {
            page = pages;
        } 

        public void SaveHTMLPage()
        {
            for(int i = 0; i < page.Length; i++)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string directory = Directory.GetCurrentDirectory();
                        Console.WriteLine(page[i].ToString());
                        string html = client.DownloadString(page[i].ToString());
                        File.WriteAllText(directory + @"\" + i + ".html", html);
                        Console.WriteLine("file saved");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : " + ex.ToString());
                }
                
            }
        }

    }
}

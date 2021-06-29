using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
namespace HttpParser
{
    class ParserImages
    {
        /// <summary>
        /// Additional functionality.
        /// Trial option to additionally parse 
        /// the page into images and save them to another directory,
        /// using Regex.
        /// </summary>

        public void GetImages(string url)
        {
            WebClient client = new WebClient();

            // Get data from page
            string data;
            using (Stream stream = client.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();
                }
            }

            //Parsing image tags
            Regex regex = new Regex(@"\<img.+?src=\""(?<imgsrc>.+?)\"".+?\>", RegexOptions.ExplicitCapture);
            MatchCollection matches = regex.Matches(data);

            // Regular expressions for check image link
            Regex fileRegex = new Regex(@"[^\s\/]\.(jpg|png|gif|bmp)\z", RegexOptions.Compiled);

            // Get image link
            var imagesUrl = matches.Cast<Match>()
                // Data from the regular expression group
                .Select(m => m.Groups["imgsrc"].Value.Trim())
                // Add the site name if the links are relative
                .Select(site => site.Contains("http://") ? site : (url + site))
                // Get the name of the picture
                .Select(site => new { site, name = site.Split(new[] { '/' }).Last() })
                // Check it
                .Where(a => fileRegex.IsMatch(a.name))
                // Delete repeating element
                .Distinct();

            // Download images
            foreach (var value in imagesUrl)
            {
                Console.WriteLine(value);
                // Download directory
                client.DownloadFile(value.site, @"E:\images\'" + value.name + "'.png");
            }
        }
    }
}

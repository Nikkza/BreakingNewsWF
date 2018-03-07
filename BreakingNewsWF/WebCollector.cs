using System;
using System.Net;

namespace BreakingNewsWF
{
    public class WebCollector : IWebColector
    {
        public string HtmlCode { get; set; }

        public void GetHtmlFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("Cant be null or empty values");
            }

            if (!url.StartsWith("https"))
            {
                throw new ArgumentException("missing https");
            }

            if (url.StartsWith("https"))
            {
                using (var client = new WebClient())
                {
                    HtmlCode = client.DownloadString(url).ToLower();
                }
            }
        }
    }
}

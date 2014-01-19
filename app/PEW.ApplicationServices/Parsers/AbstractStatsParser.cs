using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace PEW.ApplicationServices.Parsers
{
    public abstract class AbstractStatsParser
    {
        protected readonly string _url;
        protected HtmlNodeCollection _nodes;

        protected AbstractStatsParser(string url)
        {
            _url = url;
            _nodes = GetData();
        }

        protected HtmlNodeCollection GetData()
        {
            var client = new WebClient();
            using (var stream = client.OpenRead(_url))
            {
                var doc = new HtmlDocument();
                doc.Load(stream);
                return doc.DocumentNode
                    .SelectNodes("//div[@class='TSMstats']//table[@class='tblContent']//tr//td");
            }
        }

        protected int Parse(string number)
        {
            int o;
            return int.TryParse(number, out o) ? o : 0;
        }
    }
}
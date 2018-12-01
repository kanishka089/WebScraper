using CsQuery;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------------Method 1 of scraping(HTML Agility pack)--------------------------------------------------------------------------------------
            /*HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(@"https://www.emagister.com/centros.htm");
            //var title = doc.DocumentNode.SelectNodes("//a[@class='centro-title-link app_Track']").ToList();
            var names = doc.DocumentNode.SelectNodes("/html/body/div/div/main/div/div/div/div/div/h2/a").ToList();
            var descriptions = doc.DocumentNode.SelectNodes("/html/body/div/div/main/div/div/div/div/div/div/p").ToList();
            var teamList = new List<mates>();
            foreach (var node in names.Zip(descriptions, (n, d) => new mates { Name = n.InnerText, Description = d.InnerText }))
            {
                teamList.Add(node);
            }
            foreach (var item in teamList)
            {
                Console.WriteLine("Name "+item.Name);
                Console.WriteLine("Description " + item.Description);
            }*/
            //------------------------------------------------Method 2 of scraping (CSQuery)--------------------------------------------------------------------------------------
            //https://github.com/jamietre/CsQuery
            var dom = CQ.CreateFromUrl("https://www.emagister.com/centros.htm");
            string html = dom.Render();
            //var items = dom[".video-player"];
            var items = dom[".item"];

            foreach (var i in items)
            {
                var test = i.Cq().Find(".centro-title-link");
                string val = test.Text();
                Console.WriteLine(val);
                //Console.WriteLine(test.RenderSelection());
            }
            //-------------------------------------------------------------------------------------------------------------------------------------------------------
            Console.ReadLine();
        }
    }
}

using RusRoads.Domen.Models;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RusRoads.Web2.Services;

public class ParsingService
{
    public static List<News> PasrsingXml(DateTime date)
    {
        List<News> list = new List<News>();

        using (var client = new WebClient())
        {
            var response = client.DownloadString("http://192.168.0.11:5141/rss");
            using (var reader = XmlReader.Create(new StringReader(response)))
            {
                var feed = SyndicationFeed.Load(reader);

                foreach (var item in feed.Items)
                {
                    var typeAndTitle = item.Title.Text.Split("/").ToList();
                    var news = new News
                    {
                        Title = typeAndTitle[0],
                        Link = item.Links.First().Uri.ToString(),
                        Description = item.Summary.Text,
                        Category = item.Categories.First().ToString(),
                        DateCreate = item.PublishDate.Date,
                        EmployeeGuid = item.Authors.ToString(),
                        Type = typeAndTitle[1]
                    };
                    list.Add(news);
                }
            }
        }

        return list.Where(n => n.DateCreate == date).ToList();
    }
}

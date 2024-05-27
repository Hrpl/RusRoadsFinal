using RusRoads.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RusRoads.Domen.Models;
using RusRoads.Domen.XMLModel;
using System.Xml.Serialization;

namespace RusRoads.Application.Services;

public class XmlService
{
    private readonly RusRoadsDbContext _db;

    public XmlService(RusRoadsDbContext db)
    {
        _db = db;
    }

    public Rss CreateRss()
    {
        var movies = _db.News.ToList();
        var listMovieItems = new List<MovieItem>();

        foreach (var movie in movies)
        {
            var item = new MovieItem
            {
                Title = $"{movie.Title}/{movie.Type}" ,
                Link = movie.Link,
                Description = movie.Description,
                Category = movie.Category,
                Date = movie.DateCreate,
                Author = movie.EmployeeGuid
            };

            listMovieItems.Add(item);
        }
        var chanel = new Chanel{
            Title = "News",
            Description = $"Create {DateTime.Now}",
            Item = listMovieItems
        };

        var rss = new Rss
        {
            Chanel = chanel,
        };

        return rss;
    }

    public string Serialize(Rss rss)
    {
        var serialize = new XmlSerializer(typeof(Rss));

        using(var writer = new StringWriter())
        {
            serialize.Serialize(writer, rss);
            return writer.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusRoads.Domen.XMLModel;

[XmlRoot(ElementName = "item")]
public class MovieItem
{
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "link")]
    public string Link { get; set; }

    [XmlElement(ElementName = "autor")]
    public string Author{ get; set; }

    [XmlElement(ElementName = "category")]
    public string Category { get; set; }

    [XmlElement(ElementName = "pubDate")]
    public DateTime Date{ get; set; }
}


[XmlRoot(ElementName ="channel")]
public class Chanel
{
    [XmlElement(ElementName="title")]
    public string Title { get; set; }

    [XmlElement(ElementName = "description")]
    public string Description { get; set; }

    [XmlElement(ElementName = "item")]
    public List<MovieItem> Item{ get; set; }
}


[XmlRoot(ElementName = "rss")]
public class Rss
{

    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; } = "2.0";

    [XmlElement(ElementName = "channel")]
    public Chanel Chanel { get; set; }

}


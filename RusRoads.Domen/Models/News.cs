using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusRoads.Domen.Models;

public class News
{
    [Key]
    public string Guid { get; set; }


    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime DateCreate { get; set; } = DateTime.Now;

    public string EmployeeGuid {  get; set; }
    public Employee? Employee { get; set; }

    public string Type { get; set; }
}

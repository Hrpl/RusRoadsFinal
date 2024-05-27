using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusRoads.Domen.Models;

public class Employee
{
    [Key]
    public string Guid { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public IEnumerable<News> News { get; set; }
}

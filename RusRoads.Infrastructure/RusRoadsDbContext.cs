using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RusRoads.Domen.Models;

namespace RusRoads.Infrastructure;

public class RusRoadsDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<News> News { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RusRoads;Trusted_Connection=True;");
    }
}

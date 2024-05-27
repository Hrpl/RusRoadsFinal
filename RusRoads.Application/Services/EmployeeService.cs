using Microsoft.EntityFrameworkCore;
using RusRoads.Domen.Models;
using RusRoads.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusRoads.Application.Services;

public class EmployeeService
{
    private readonly RusRoadsDbContext _db;

    public EmployeeService(RusRoadsDbContext db)
    {
        _db = db;
    }

    public async Task<Employee> Auth(string login, string password)
    {
        var employee = await _db.Employees.Where(e => e.Name == login && e.Password == password).FirstOrDefaultAsync();
        return employee;
    }
}

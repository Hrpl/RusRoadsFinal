using RusRoads.Infrastructure;
using RusRoads.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace RusRoads.Application.Services;

public class NewsService
{
    private readonly RusRoadsDbContext _db;
    
    public NewsService(RusRoadsDbContext db)
    {
        _db = db;
    }

    public async Task<bool> AddNews(News news)
    {
        if (news != null)
        {
            _db.News.Add(news);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        else return false;
    }


    public async Task<List<News>> FilterOnType(string type)
    {
        var listNews = await _db.News.Where(n => n.Type == type).ToListAsync();
        return listNews;
    }
    
}

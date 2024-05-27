using RusRoads.Application.Services;
using RusRoads.Domen.Models;
using RusRoads.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using RusRoads.Application;
using RusRoads.Application.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSignalR(b => {
    b.ClientTimeoutInterval = TimeSpan.FromHours(1);
    b.KeepAliveInterval = TimeSpan.FromHours(1);
    b.ClientTimeoutInterval = TimeSpan.FromHours(1);
});

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<XmlService>();
builder.Services.AddScoped<NewsService>();

builder.Services.AddSingleton<ChatHub>();

builder.Services.AddDbContext<RusRoadsDbContext>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
Console.WriteLine(key);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {

           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = configuration["Jwt:Issuer"],
           ValidAudience = configuration["Jwt:Audience"],
           IssuerSigningKey = key,

       };
   });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => b.AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();
app.UseAuthentication();


app.MapHub<ChatHub>("/newsHub");

app.Run();

using RusRoads.Server.Hubs;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(b =>
{
    b.ClientTimeoutInterval = TimeSpan.FromHours(1);
    b.HandshakeTimeout = TimeSpan.FromHours(1);
    b.KeepAliveInterval = TimeSpan.FromHours(1);
});

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin());

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");

app.Run();

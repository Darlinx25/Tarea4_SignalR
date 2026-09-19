using Microsoft.AspNetCore.SignalR;
using Tarea4_SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.MapHub<LoginHub>("/loginHub");

app.MapGet("/verificar/usuario/{connectionId}", async (string connectionId, IHubContext<LoginHub> hubContext, ILogger<LoginHub> logger) =>
{
    logger.LogInformation($"Notificando al cliente {connectionId}");
    await hubContext.Clients.Client(connectionId).SendAsync("VerificacionOk", connectionId);
});

app.Run();
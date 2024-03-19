using KanbanBoard_Blazor;
using KanbanBoard_Blazor.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var dbHost = "localhost";
var dbName = "kanbanApp";
var dbPassword = "kanban@123";
var connectionString = $"Server={dbHost};Database={dbName};User Id=sa;Password={dbPassword};";
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

await builder.Build().RunAsync();

using SimpleToDoManager.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SimpleToDoManager.Data;
using SimpleToDoManager.Services;
using SimpleToDoManager.Interfaces;

var services = new ServiceCollection();
services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=todo.db"));
services.AddScoped<IToDoService, ToDoService>();
services.AddTransient<Menu>();
var serviceProvider = services.BuildServiceProvider();
try
{
    using var scope = serviceProvider.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    var menu = scope.ServiceProvider.GetRequiredService<Menu>();
    menu.Run();
}
catch(Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error: {e.Message}");
    Console.ResetColor();
}
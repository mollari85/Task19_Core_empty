using Task19_Core_empty.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PersonInfoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonInfoContext") ?? throw new InvalidOperationException("Connection string 'PersonInfoContext' not found.")));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPhoneBookModel, PhoneBookModel>();

var app = builder.Build();
app.MapControllerRoute(name: "default", pattern: "{controller=PhoneBook}/{action=Index}/{id?}");
app.MapControllerRoute(name: "person", pattern: "{controller=PersonInfo}/{action=Index}/{id?}");
//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

//app.UseRouting();
//PhoneBookModel PhoneBook = new PhoneBookModel();
object locker = new();
lock (locker)
{
    using (FileStream fs = new FileStream("Data.json", FileMode.OpenOrCreate))
    {
        List<PersonInfo> Book = new List<PersonInfo>() {new PersonInfo(1,"Vasya","Vas",null,"89162182299",null,null) ,
                new PersonInfo(2,"Alla","Elnikova","Petrovich","89162182298","Moscow","Good girl"),
                new PersonInfo(3,"Katya","Drozd","Petrovich","8916218898","Moscow","Bad girl")
            };
        JsonSerializer.Serialize<List<PersonInfo>>(fs, Book);
    }
}
lock (locker)
{
    using (FileStream fs = new FileStream("Data.json", FileMode.OpenOrCreate))
    {
        List<PersonInfo>? tmp = JsonSerializer.Deserialize<List<PersonInfo>>(fs);

        List<PersonInfo>Book = tmp ?? new List<PersonInfo>();
    }
}
app.Run();



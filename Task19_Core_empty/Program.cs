using Task19_Core_empty.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using Task19_Core_empty.Entitys;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PersonInfoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonInfoContext") ?? throw new InvalidOperationException("Connection string 'PersonInfoContext' not found.")));

builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IPhoneBookModel, PhoneBookModel>();
builder.Services.AddTransient<IPhoneBookModel, PhoneBookModelSQL>();

var app = builder.Build();
//app.MapControllerRoute(name: "personInfo", pattern: "{controller}/Index/{action}/{Id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=PhoneBook}/{action=Index}/{id?}");
app.MapControllerRoute(name: "person", pattern: "{controller}/{action=Index}/{id?}");

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

//app.UseRouting();
//PhoneBookModel PhoneBook = new PhoneBookModel();

    using (FileStream fs = new FileStream("Data.json", FileMode.OpenOrCreate))
    {
        List<PersonInfo> Book = new List<PersonInfo>() {new PersonInfo(1,"Vasya","Vas",null,"89162182299",null,null) ,
                new PersonInfo(2,"Alla","Elnikova","Petrovich","89162182298","Moscow","Good girl"),
                new PersonInfo(3,"Katya","Drozd","Petrovich","8916218898","Moscow","Bad girl")
            };
        JsonSerializer.Serialize<List<PersonInfo>>(fs, Book);
    }


    using (FileStream fs = new FileStream("Data.json", FileMode.OpenOrCreate))
    {
        List<PersonInfo>? tmp = JsonSerializer.Deserialize<List<PersonInfo>>(fs);

        List<PersonInfo>Book = tmp ?? new List<PersonInfo>();
   }
/* 
using (ApplicationContext db = new ApplicationContext())
{
List<PersonInfo> Book = new List<PersonInfo>() {new PersonInfo(1,"Vasya","Vas",null,"89162182299",null,null) ,
            new PersonInfo(2,"Alla","Elnikova","Petrovich","89162182298","Moscow","Good girl"),
            new PersonInfo(3,"Katya","Drozd","Petrovich","8916218898","Moscow","Bad girl")
        };

db.Persons.AddRange(Book);
db.SaveChanges();
var config = new ConfigurationBuilder()
           .AddJsonFile($"Properties\\launchSettings.json", true, true)
           .SetBasePath(Directory.GetCurrentDirectory())
.Build();

string connection=config.GetConnectionString("DefaultConnectionSQL");
using (SqlConnection Sql = new SqlConnection(connection))
{
    Sql.Open();
    Console.WriteLine("hi here is I" + Sql.State.ToString());
    Console.ReadLine();
    Sql.Close();
}
}
*/
app.Run();



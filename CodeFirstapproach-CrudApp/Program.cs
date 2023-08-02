using CodeFirstapproach_CrudApp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var provider = builder.Services.BuildServiceProvider();
var config=provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<student_Db_context>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#region Summary
/*
 * Code First Aprroach:
 * step 01:
 * install 3 packages in asp.net core application:
 * Microsoft.EntityFrameWork.SqlServer
 * Microsoft.EntityFrameWork.Tools
 * Primarly used for manage migration and automatic generation of views
 * Microsoft.EntityFrameWork.Design
 * contains all design-time logic for Entity frame Work:
 *  step 02:
 *  create model class:
 *  create DB_context class [intract with data base and our model class code],integral part of Entity framework
 *  it is the class responsible to database connetion and retrieve and save data
 *  An instance of DB_context represent session with the database
 *  DB_context connection of unit of work and repository pattern
 *  DB_context coordinate with EF and allow us to query and save data
 *  DB_context uses  DBSET<modelclass> T represents table of an object which has to be save in database
 *  for working to do use full work we have to create a instance of DBContextOption and pass it to base class
 *  DBContextOption carrries connection string and database providers
 *  
 *  
 *  step 03:
 *  create a connection string in appsetting.json file
 *  
 *  step 04:
 *  register connetion string in program.cs
 *  
 *  step 05 
 *  add migration and then run
 * now if we want to add another column in DB
 * add-migration DBFirstAddClass
 * update-database
 * step -06
 * define property of Db context and assaign in constructor by that property we can access any table from database
 */
#endregion

#region Implementation of Action methods like delete ,create, Edit in Crud application
/*
 * 
 */
#endregion

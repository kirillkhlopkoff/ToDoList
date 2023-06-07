using Microsoft.EntityFrameworkCore;
using ToDoListStudy.DAL;
using ToDoListStudy.DAL.Interfaces;
using ToDoListStudy.DAL.Repisitories;
using ToDoListStudy.Domain.Entity;
using ToDoListStudy.Service.Implementations;
using ToDoListStudy.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<AppDbContext>(optionsAction: options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();

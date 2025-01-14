using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Config;
using DataAccess.MyContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));
//AutoMapper
var configMap = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MyMap());

});
builder.Services.AddSingleton(configMap.CreateMapper());

// Services
builder.Services.AddScoped<ICategory,CategoryService>();
builder.Services.AddScoped<IProduct,ProductService>();
builder.Services.AddScoped<IMessage,MessageService>();
builder.Services.AddScoped<ILogin,LoginService>();
builder.Services.AddScoped<IRole,RoleService>();

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

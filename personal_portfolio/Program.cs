using Microsoft.EntityFrameworkCore;
using Personal_Portfolio.Data;
using Personal_Portfolio.Models;
using Personal_Portfolio.Services;

string getConnectionString(WebApplicationBuilder builder)
{
    // ElephantSQL formatting
    var optionsBuilder = new DbContextOptionsBuilder<ContactContext>();
    // ElephantSQL formatting
    var uriString = builder.Configuration.GetConnectionString("cloudConnectionString")!;
    var uri = new Uri(uriString);
    var db = uri.AbsolutePath.Trim('/');
    var user = uri.UserInfo.Split(':')[0];
    var passwd = uri.UserInfo.Split(':')[1];
    var port = uri.Port > 0 ? uri.Port : 5432;
    var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
        uri.Host, db, user, passwd, port);
    return connStr;
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ISkillsDataRepository<string>, SkillsDataRepository>();
builder.Services.AddScoped<IProjectsDataRepository<ProjectCardModel>, ProjectsDataRepository>();
builder.Services.AddScoped<IBlogsDataRepository<BlogModel>, BlogsDataRepository>();
builder.Services.AddScoped<IContactsDataRepository<ContactMeModel>, SqlContactsDataRepository>();


// builder.Services.AddMvc()
//     .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);

builder.Services.AddDbContextPool<ContactContext>(
    options =>
    {
        var connStr = getConnectionString(builder);
        options.UseNpgsql(
                connStr
        );
    }
);



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

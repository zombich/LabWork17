using CinemaWeb.Contexts;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU") { NumberFormat = { NumberDecimalSeparator = "." } };
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CinemaDbContext>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

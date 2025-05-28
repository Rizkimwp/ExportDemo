using Rotativa.AspNetCore;
using OfficeOpenXml;
using System.IO;
var builder = WebApplication.CreateBuilder(args);
// Atur license context ke NonCommercial
    ExcelPackage.License.SetNonCommercialPersonal("Rizki Maulana");

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

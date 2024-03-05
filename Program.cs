using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegistrationForm.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RegistrationFormContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationFormContext") ?? throw new InvalidOperationException("Connection string 'RegistrationFormContext' not found.")));



builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Register}/{action=Register}/{id?}");

app.Run();

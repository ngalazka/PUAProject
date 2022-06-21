using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using PUAProject.Models;





var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddDbContext<PUA20832Context>(options => options.UseSqlServer(

                builder.Configuration.GetConnectionString("DefaultConnection"),

                options => options.CommandTimeout(3600))

            );
builder.Services.AddControllersWithViews(options =>
{
    //var policy = new AuthorizationPolicyBuilder()
    //    .RequireAuthenticatedUser()
    //    .Build();
    //options.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation()
    .AddMicrosoftIdentityUI()
    ;

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".FunnySocks.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(20);

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    }
     //Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseSession();
    app.UseRouting();


    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSwagger();
    app.UseSwaggerUI();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
    app.UseAuthentication(); ;

    app.Run();


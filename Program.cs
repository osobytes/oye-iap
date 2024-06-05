using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using OyeIap.Server;
using OyeIap.Server.Areas.Identity;
using OyeIap.Server.Data;
using OyeIap.Server.Data.ViewModel;
using OyeIap.Server.Grid;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={ApplicationDbContext.OyeIapDbName}.db"));
builder.Services.AddFluentUIComponents()
    .AddDataGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
// builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IPageHelper, PageHelper>();
builder.Services.AddScoped<IBaseGridControls, BaseGridControls>();
builder.Services.AddScoped<InstitucionQueryAdapter>();
builder.Services.AddScoped<AlumnoQueryAdapter>();
builder.Services.AddScoped<TutorQueryAdapter>();

// Service to communicate success on edit between pages
builder.Services.AddScoped<EditSuccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
    await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
    var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
    await DatabaseUtility.EnsureDbCreatedAndSeedWithCountOfAsync(options, 500);
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


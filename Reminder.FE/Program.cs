using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Reminder.BE;
using Reminder.BE.Repositories;
using Reminder.DB.Interfaces;
using Reminder.FE.Controllers;
using Reminder.FE.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration["DefaultConnection"];
//builder.Services.AddSignalR();

//builder.Services.AddQuartz(q =>
//{
//    q.UseMicrosoftDependencyInjectionScopedJobFactory();
//    var jobKey = new JobKey("EmanEmailJob");
//    q.AddJob<EmanEmailJob>(opts => opts.WithIdentity(jobKey));

//    q.AddTrigger(opts => opts
//        .ForJob(jobKey)
//        .WithIdentity("EmanEmailJob-trigger")
//        .WithCronSchedule("0/5 * * * * ?"));

//});

//builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

//builder.Services.AddHostedService<QuartzHostedService>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHangfire(x => x.
SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
.UseSqlServerStorage(connectionString, new Hangfire.SqlServer.SqlServerStorageOptions()
{
    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
    QueuePollInterval = TimeSpan.FromMinutes(5),
    UseRecommendedIsolationLevel = true,
    DisableGlobalLocks = true,
}));
builder.Services.AddHangfireServer();
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

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.UseHangfireDashboard("/dashboard");
app.Run();

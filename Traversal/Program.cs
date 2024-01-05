using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using PresentationLayer.CQRS.Handlers.DestinationHandlers;
using PresentationLayer.Models;


//************made on my own start for Authentication
//****************made on my own end

var builder = WebApplication.CreateBuilder(args);

//************made on my own start for using CQRS
builder.Services.AddScoped<GetDestinationsForStrangersQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();
//****************made on my own end

//************made on my own start for using CQRS(MediatR)
builder.Services.AddMediatR(typeof(Program));
//****************made on my own end



//************made on my own start for Logging
builder.Services.AddLogging(x =>
{
    x.ClearProviders();//ilk olaraq providerleri temizledik
    x.SetMinimumLevel(LogLevel.Debug);//Log iprossesi hardan baslasin demekdir
    x.AddDebug(); //logu elave etdik
    //indi ise loglamanin harada istifade edileceyini secmeyimiz lazimdir.Istifade etmek ucun baslanqicda Home conttrollerin icerisinde hazir olaraq ILoggerden _logger ozu yaradir.
    //buloglari fayla yuklemek ucun ise Ui da nugetpackageden serilog.extensions.logging.file-i yukleyirik
});


//****************made on my own end
// Add services to the container.
//*****************made on my own start for Identity library
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Lockout.AllowedForNewUsers = true;
    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    x.Lockout.MaxFailedAccessAttempts = 3;
    //x.Password.RequireNonAlphanumeric = false;   
}).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

//Yaratmis olduqumuz Api ni istifade etmek ucun confiqurasiya start
builder.Services.AddHttpClient();
//Yaratmis olduqumuz Api ni istifade etmek ucun confiqurasiya end


//Extension daki yaratdiqimiz metodu asaqidaki kimi caqirdiq
builder.Services.ContainerDependencies();
//****************made on my own end



//************made on my own start for AutoMapping
builder.Services.AddAutoMapper(typeof(Program));

//Indi ise validasyalari elave edek
//Businnessdeki containerin icindeki yaratdiqimiz CustomValidator() metodu bunu edir
//Bunu caqirmaq lazimdi indi caQIRMAQ UCUN:
builder.Services.CustomValidator();

//Indi ise Fluent istifade ucin config yazaq
builder.Services.AddControllersWithViews().AddFluentValidation();
//builder.Services.AddAutoMapper(typeof(Program).Assembly);
//****************made on my own end


builder.Services.AddControllersWithViews();

//************made on my own start for Authentication
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
//************made on my own start for Multi Languages
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});
//davami addMvc() nin ardindadi.Buradaki resources ise dil fayllarinin olduqu pafqanin adidi.addMvc() nin ardindan ise UseAuthorizationun()
//altindakileri yaziriq
//****************made on my own end for multi Languages

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
//****************made on my own end for authentication



var app = builder.Build();
//************made on my own start for Loggingfile
//ILoggerFactory loggerfactory;
var loggerFactory = app.Services.GetService<ILoggerFactory>();
var path = Directory.GetCurrentDirectory();
loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
//****************made on my own end



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//***********made on my own start for ErroPages
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
//***********made on my own end for ErroPages

app.UseHttpsRedirection();
app.UseStaticFiles();
//***********made on my own start for Authentication

    app.UseAuthentication();
//Authentication,bir kullanıcının herhangi bir kaynağa erişimde kimliğinin doğrulanması işlemidir. 
//Kullanıcıya Kimsin sorusu sorulur? Bu sorunun cevabı genellikle kullanıcının kullanıcı  adı ve  şifre şeklinde cevap vermesiyle yanıtlanır.
//Authentication, authorization'dan önce gelmektedir.
//Authorization ise, kimliği doğrulanan kullanıcının erişmek istediği kaynak üzerindeki yetkilerini tanımlar.
//Peki authentication işlemi yapılmadan authorization işlemi yapılamaz mı?
//Kimsin sorusunun sorulmaması demek herhangi birisi anlamına gelir. 
//Dolayısı ile kimliği doğrulanmayan yani anonim kullanıcılara izin verileceği durumlarda bu işlem gerçekleştirilir.
//*********made on my own end
app.UseRouting();


app.UseAuthorization();

//************made on my own start for Multi Languages
var supportedCultures = new[] { "en", "fr", "tr", "de", "az"}; 
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);
//************made on my own end for Multi Languages



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//});

app.Run();

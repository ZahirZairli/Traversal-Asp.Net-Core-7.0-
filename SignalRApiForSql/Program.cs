using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Hubs;
using SignalRApiForSql.Models;

var builder = WebApplication.CreateBuilder(args);

//apinin istifadesi ucun lazim olan configler start
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    bilder =>
    {
        bilder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    }));
//end


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//for using this api config on my own start
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration["DefaultConnection"]);
});

//end

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//config for using this api start
app.UseCors("CorsPolicy");
//end


app.MapControllers();


//bu apide hansi hissenin istifadesini mueyyen etmek ucun config start
app.MapHub<VisitorHub>("/VisitorHub");
//end

app.Run();

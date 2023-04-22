using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Model;

var builder = WebApplication.CreateBuilder(args);

//apinin istifadesi ucun lazim olan configler start
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();
builder.Services.AddCors(options=>options.AddPolicy("CorsPolicy",
    bilder =>
    {
        bilder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    }));
//end


//postegre sql üçün appsettings.json da yaratmış olduğumuz Connectionstring i işlətmək üçün config start
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt=>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//end

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

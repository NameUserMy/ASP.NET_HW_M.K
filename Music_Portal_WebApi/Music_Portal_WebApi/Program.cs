using HW_7_MusicPortal.Services;
using MusicPortal.BLL.Infrastructure;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddMusicPortalContext("Data Source=./Data/MusicPortal.db");
builder.Services.AddUOW();
builder.Services.Admin();
builder.Services.AddScoped<Encryption>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

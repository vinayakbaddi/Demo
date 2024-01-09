using Hangfire;
using Microsoft.EntityFrameworkCore;
using SpikeHangfire.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Data\TestDB.mdf;Integrated Security=True"));
//Use this below
//builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True"));

//builder.Services.AddHangfire()

//builder.Services.AddHangfireServer();

builder.Services.AddDbContext<HangFireDBContext>(opt=>
opt.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=Data\\TestDB.mdf;Integrated Security=True")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseAuthorization();

app.MapControllers();

app.Run();

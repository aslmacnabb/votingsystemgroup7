using server.Accessors;
using server.Managers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { options.AddDefaultPolicy(policy  => { policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod(); }); });

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

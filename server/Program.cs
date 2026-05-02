using server.Accessors;
using server.Managers;

AdminManager am = new AdminManager();
am.AddElection("HuskersAdmin", "AE4F2B96EF123FF6D8DD1C74FA7E77F8E2837F30F9E8FBFBC3B6A9EF4B5C6D7E8", "Toad on Steam Election");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { options.AddDefaultPolicy(policy  => { policy.WithOrigins("http://localhost:5173"); }); });

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

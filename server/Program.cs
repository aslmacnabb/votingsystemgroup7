using server.Accessors;
using server.Managers;

// test UserManager
UserManager um = new UserManager(new UserAccessor());
Console.WriteLine(um.Authenticate("HuskersAdmin", "AE4F2B96EF123FF6D8DD1C74FA7E77F8E2837F30F9E8FBFBC3B6A9EF4B5C6D7E8"));
VoteAccessor va = new VoteAccessor();
// get SelectionValue of Vote with id 1
Console.WriteLine(va.GetString(1, "SelectionValue"));
UserAccessor ua = new UserAccessor();
ua.SetInt(1, "FailedLoginAttempts", 5);
Console.WriteLine(ua.GetInt(1, "FailedLoginAttempts"));

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllers();

app.Run();

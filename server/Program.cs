using server.Accessors;

// test UserAccessor
UserAccessor ua = new UserAccessor();
Console.WriteLine(ua.GetString(1, "Email")); // get email
VoteAccessor va = new VoteAccessor();
// get SelectionValue of Vote with id 1
Console.WriteLine(va.GetString(1, "SelectionValue"));

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
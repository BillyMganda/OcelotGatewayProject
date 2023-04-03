using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MINE
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

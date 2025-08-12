using Microsoft.EntityFrameworkCore;
using Wallet.Core.DataBases;
using Wallet.Core.Abstract;
using Wallet.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => 
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AppDbContext)));
    });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository,UsersRepository>();

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

using Application.Service;
using Json.Data;
using Json.Service;
using Microsoft.EntityFrameworkCore;
using WebUI;
using WebUI.Middleware;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<ConsoleAppDatabase>(option =>
{
    option.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 10, 28)));
});

builder.Services.AddScoped<CRUD>();
builder.Services.AddScoped<DownloadExch>();


builder.Services.AddCors(options => {
    options.AddPolicy("MyPolice", policy => {
        policy.AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(opt => true);
    });
});

var app = builder.Build();

app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();

app.UseCors("MyPolice");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();



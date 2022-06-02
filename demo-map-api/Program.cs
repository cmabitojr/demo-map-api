using demo_map_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using demo_map_api.Model;
using Microsoft.Extensions.Configuration;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
//app.UseCors(options =>
//     options.WithOrigins("http://localhost:7066")
//            .AllowAnyHeader()
//            .AllowAnyMethod());

//app.UseCors(myAllowSpecificOrigins);
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: myAllowSpecificOrigins,
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:7066"
//                )
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//        });
//});

app.MapControllers();

app.Run();


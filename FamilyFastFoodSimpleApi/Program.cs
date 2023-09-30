using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FamilyFastFoodSimpleApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FamilyFastFoodSimpleApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FamilyFastFoodSimpleApiContext"),
    sqlOptions => sqlOptions.EnableRetryOnFailure()
   ));

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
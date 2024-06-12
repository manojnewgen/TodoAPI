using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt=> opt.UseInMemoryDatabase("TodoList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{
        Version="v1",
        Title="Todo Test API- Manoj",
        Description="this is test api for generating open api",
        TermsOfService= new Uri("https://example.com/terms"),
         Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }

    });
});

var app = builder.Build();

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

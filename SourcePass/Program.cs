using SourcePass.Repositories.Entities;
using SourcePass.Repositories.Repositories;
using SourcePass.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormQuestionRepository, FormQuestionRepository>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

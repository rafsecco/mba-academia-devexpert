using AcademiaDevExpert.Conteudo.Application.AutoMapper;
using AcademiaDevExpert.WebApp.API.Configurations;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerConfigureServices();
builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
builder.Services.AddMediatR(typeof(Program));
builder.Services.RegisterServices();

var app = builder.Build();
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

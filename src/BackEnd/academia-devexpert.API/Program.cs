using academia_devexpert.API.Configuracoes;


var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseSelector();
builder.AddIdentityConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfigureServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseSwaggerConfiguration();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseDbMigrationHelper();
app.Run();

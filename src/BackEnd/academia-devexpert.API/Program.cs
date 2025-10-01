using academia_devexpert.API.Configuracoes;
using academia_devexpert.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Add this using directive at the top
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Conectar ao banco de dados (ajuste a connection string conforme necessário)
builder.Services.AddDbContext<SolutionDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
//	.AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityConfiguration(builder.Configuration);

// Configuração de autenticação
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Specify the scheme
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;
		options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SeuSegredoDeChaveAqui"))
		};
	});


builder.Services.AddControllers();
builder.Services.AddSwaggerConfigureServices();



var app = builder.Build();
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

using petTrackerApi.Data;
using petTrackerApi.Repository;
using petTrackerApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Services.GenericServices;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Services

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMascotaService, MascotaService>();
builder.Services.AddScoped<IVacunaService, VacunaService>();
builder.Services.AddScoped<IDesparacitacionService, DesparacitacionService>();
builder.Services.AddScoped<IGenericService<RazaDTO>, RazaService>();
builder.Services.AddScoped<IGenericService<TipoDesparacitacionDTO>, TipoDesparacitacionService>();
builder.Services.AddScoped<IGenericService<TipoEventoDTO>, TipoEventoService>();
builder.Services.AddScoped<IGenericService<TipoVacunaDTO>, TipoVacunaService>();
builder.Services.AddScoped<IGenericService<TipoAlimentoDTO>, TipoAlimentoService>();
builder.Services.AddScoped<IGenericService<RazaDTO>, RazaService>();
builder.Services.AddScoped<IGenericService<EspecieDTO>, EspecieService>();

//Repository

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();
builder.Services.AddScoped<IVacunaRepository, VacunaRepository>();
builder.Services.AddScoped<IDesparacitacionRepository, DesparacitacionRepository>();
builder.Services.AddScoped<IGenericRepository<Especie>, EspecieRepository>();
builder.Services.AddScoped<IGenericRepository<Raza>, RazaRepository>();
builder.Services.AddScoped<IGenericRepository<TipoDesparacitacion>, TipoDesparacitacionRepository>();
builder.Services.AddScoped<IGenericRepository<TipoEvento>, TipoEventoRepository>();
builder.Services.AddScoped<IGenericRepository<TipoVacuna>, TipoVacunaRepository>();
builder.Services.AddScoped<IGenericRepository<TipoAlimento>, TipoAlimentoRepository>();

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//primera parte
var key = builder.Configuration["ApiSetting:Secreta"];
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();

//CORS
var origenLocalHost = "_origenLocalHost";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
              .AllowAnyHeader()
              .AllowAnyMethod()
    );

    options.AddPolicy(origenLocalHost, policy =>
        policy.SetIsOriginAllowed(origin =>
        {
            try
            {
                return
                    origin.StartsWith("http://192.168.1.") ||
                    origin.StartsWith("http://localhost") ||
                    origin.StartsWith("http://localhost:4200/");
            }
            catch
            {
                return false;
            }
        })
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//segunda parte

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
        "Autenticación JWT usando el esquema Bearer. \r\n\r\n " +
        "Ingresa la palabra 'Bearer' seguida de un [espacio] y despues su token en el campo de abajo \r\n\r\n" +
        "Ejemplo: \"Bearer tkdknkdllskd\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}


app.UseHttpsRedirection();

app.UseCors("_origenLocalHost");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

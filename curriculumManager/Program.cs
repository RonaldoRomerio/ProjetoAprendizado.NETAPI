using curriculumManager.src.application.interfaces;
using curriculumManager.src.application.mapping;
using curriculumManager.src.application.services;
using curriculumManager.src.client.middleware;
using curriculumManager.src.infrastructure.Authentication.JWTAuth;
using curriculumManager.src.infrastructure.database.config;
using curriculumManager.src.infrastructure.database.seeds;
using curriculumManager.src.infrastructure.repositories;
using curriculumManager.src.infrastructure.repositories.interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("dbConnection")));

builder.Services.AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<IExperienceRepository, ExperienceRepository>()
                .AddTransient<IEducationRepository, EducationRepository>()
                .AddScoped<IUserLogin, UserService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IExperienceService, ExperienceService>()
                .AddScoped<IEducationService, EducationService>();

builder.Services.AddAutoMapper(typeof(EntityToDTOMappingProfile));

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name="Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<String>()
        }
    }); 
});

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<exceptionMiddleware>();

app.MapControllers();

SeedData.Seed(app);

app.Run();

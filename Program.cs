using DesafioBackEnd;
using DesafioBackEnd.API.Dependencies;
using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Application.Mapping.Config;
using DesafioBackEnd.Application.Services;
using DesafioBackEnd.Infra.Data;
using DesafioBackEnd.Infra.Messaging.RabbitMQ;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

ConfigureAuthentication(services);
ConfigureAuthorization(services);
ConfigureAutoMapper(services);
ConfigureSwagger(services);
ConfigureRabbitMQ(services);
ConfigureServices(services);


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


// Configure o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio V1");
    });
}

app.Run();


void ConfigureAuthentication(IServiceCollection services)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


}

void ConfigureAuthorization(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy =>
            policy.RequireRole("admin"));
        options.AddPolicy("UserOnly", policy =>
            policy.RequireRole("Usuario"));
    });
}

void ConfigureRabbitMQ(IServiceCollection services)
{
    var rabbitMqOptions = new RabbitMqOptions();
    builder.Configuration.GetSection("RabbitMQ").Bind(rabbitMqOptions);

    services.AddSingleton<IMessageBroker>(sp =>
    {
        return new RabbitMqMessageBroker(rabbitMqOptions.URL);
    });

    services.AddScoped<MotorcycleEventPublisher>();

    services.AddSingleton<IHostedService, MessageSubscriberService>();

    services.AddSingleton<IMotorcycleRegisteredEventHandler, MotorcycleRegisteredEventHandler>();

}

void ConfigureSwagger(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio", Version = "v1" });
        //c.OperationFilter<SwaggerUploadOperationFilter>();
        // Configuração do suporte a Bearer Token
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
        });
    });
}

void ConfigureServices(IServiceCollection services)
{
    services.AddHttpContextAccessor();

    services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressInferBindingSourcesForParameters = true;
            options.SuppressModelStateInvalidFilter = true;
        });

    services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

    services.AddTransient<TokenService>();

    ApplicationDependencyInjector.Add(services);
    RepositoriesDependencyInjector.Add(services);
}

void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    MappingsConfig.RegisterMappings();
}



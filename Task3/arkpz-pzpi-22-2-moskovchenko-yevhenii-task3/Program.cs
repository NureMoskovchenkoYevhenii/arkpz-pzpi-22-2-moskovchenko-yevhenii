using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Додайте базову аутентифікацію
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Реєстрація репозиторіїв
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDayTypeRepository, DayTypeRepository>();
builder.Services.AddScoped<IWorkingDayRepository, WorkingDayRepository>();
builder.Services.AddScoped<IUserWorkingDayRepository, UserWorkingDayRepository>();
builder.Services.AddScoped<IChangeRequestRepository, ChangeRequestRepository>();
builder.Services.AddScoped<IUserChangeRequestRepository, UserChangeRequestRepository>();

// Додайте сервіси до контейнера
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DayTypeService>();
builder.Services.AddScoped<WorkingDayService>();
builder.Services.AddScoped<UserWorkingDayService>();
builder.Services.AddScoped<ChangeRequestService>();
builder.Services.AddScoped<UserChangeRequestService>();

// Реєстрація маперів
builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<DayTypeMapper>();
builder.Services.AddScoped<WorkingDayMapper>();
builder.Services.AddScoped<ChangeRequestMapper>();
builder.Services.AddScoped<UserWorkingDayMapper>();
builder.Services.AddScoped<UserChangeRequestMapper>();

// Реєстрація репозиторіїв
builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();

// Реєстрація сервісів
builder.Services.AddScoped<SensorDataService>();

// Реєстрація маперів
builder.Services.AddScoped<SensorDataMapper>();

// Додайте Swagger для документації API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Додайте базову аутентифікацію до Swagger
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authentication"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Налаштування HTTP-запитів
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// Додайте обслуговування статичних файлів
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // Додайте аутентифікацію
app.UseAuthorization();

app.MapControllers(); // Це налаштовує маршрутизацію для контролерів

app.Run();

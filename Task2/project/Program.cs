using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(); // Додайте ваш контекст бази даних

builder.Services.AddScoped<UserService>(); // Додайте ваші сервіси
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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Налаштування HTTP-запитів
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();

    // Використовуйте ваш файл специфікації
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V0");
    });

}

// Додайте обслуговування статичних файлів
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Це налаштовує маршрутизацію для контролерів

app.Run();

using AutoMapper;
using WebApi.Profiles;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Получение конфигурации мапера
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
            {
                new ReportProfile()
            }));

            // Регистрация мапера в DI
            builder.Services.AddScoped<IMapper>(m => new Mapper(config));

            // Добавление CORS политики 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
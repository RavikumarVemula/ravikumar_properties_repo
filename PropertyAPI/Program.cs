
using PropertyAPI.Extensions.EndPoints;
using PropertyAPI.Extensions;
using PropertyAPI.Middleware;
using InfrastructureLayer.Storage;
using ApplicationLayer;
using InfrastructureLayer;

namespace PropertyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.AddControllers();
            builder.Services.AddCorsExtension();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<AzureStorageOptions>(builder.Configuration.GetSection("AzureStorageOptions"));
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddEndpointsExtension(AssemblyReference.Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowReactApp");

            app.UseHttpsRedirection();

            app.UseExceptionHandler();

            app.UseAuthorization();

            app.MapControllers();
            //Defined extension 
            app.UseMapEndpoints();

            app.Run();
        }
    }
}

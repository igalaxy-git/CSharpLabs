using System.ComponentModel;
using Lab4;

namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            TypeDescriptor.AddAttributes(typeof(Double));

            AppDbContext context = new AppDbContext("db.sqlite");

            Calculator service = new Calculator(context);

            app.MapGet("/get operator", (HttpContext httpContext, string op) =>
            {
                return service.GetOperator(op);
            })
            .WithName("GetOperator")
            .WithOpenApi();

            app.MapGet("/get operand", (HttpContext httpContext, DateOnly from, DateOnly to) =>
            {
                return service.GetOperand();
            })
            .WithName("GetOperand")
            .WithOpenApi();


            app.Run();
        }
    }
}

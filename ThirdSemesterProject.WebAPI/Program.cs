
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*builder.Services.AddSingleton<IDAO<Product>, ProductDAOStub>();*/

            //Docker ConnectionString: 
            const string connectionString = "Server=tcp:localhost,1433;Database=webshop;User ID=sa;Password=Dockerstrongpwd123;";

            //SSMS connectionString: 
            //const string connectionString = "Data Source=.;Initial Catalog=webshop;Integrated Security=True";
            builder.Services.AddSingleton<IDAOAsync<Product>>((_) => (IDAOAsync<Product>) new ProductDAO(connectionString));
            builder.Services.AddSingleton<IDAOAsync<SaleOrder>>((_) => (IDAOAsync<SaleOrder>)new SaleOrderDAO(connectionString));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

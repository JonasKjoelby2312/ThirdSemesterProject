
using ThirdSemesterProject.DAL.DAOs;
using ThirdSemesterProject.DAL.Model;
using ThirdSemesterProject.WebAPI.DTOs;

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
            const string connectionString = "Server=tcp:hildur.ucn.dk,1433;Database=DMA-CSD-S232_10503126;User ID=DMA-CSD-S232_10503126;Password=Password1!;";

            //SSMS connectionString: 
            /*const string connectionString = "Data Source=.;Initial Catalog=webshop;Integrated Security=True";*/
            builder.Services.AddSingleton<IDAOAsync<Product>>((_) => (IDAOAsync<Product>) new ProductDAO(connectionString));
            builder.Services.AddSingleton<ISaleOrderDAO>((_) => (ISaleOrderDAO)new SaleOrderDAO(connectionString));
            builder.Services.AddSingleton<ICustomerDAO> ((_) => (ICustomerDAO)new CustomerDAO(connectionString));
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

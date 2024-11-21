using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ThirdSemesterProject.DAL.Authentication;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs
{
    public class CustomerDAO : BaseDAO, ICustomerDAO
    {
        private readonly string INSERT_CUSTOMER = "";
        private readonly string INSERT_PERSON = "";
        private readonly string INSERT_ADDRESS = "";
        public CustomerDAO(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<int> CreateAsync(Customer entity, string password)
        {
            using var connection = CreateConnection();
            IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var passwordHash = BCryptTool.HashPassword(password);
                connection.Open();
                int addressId = await connection.ExecuteScalarAsync<int>(INSERT_ADDRESS, entity, transaction);
                int personId = await connection.ExecuteScalarAsync<int>(INSERT_PERSON, new { fk_address_id = addressId, name = entity.Name, email = entity.Email, phone_no = entity.PhoneNO, password = passwordHash, person_type = "Customer"}, transaction );
                await connection.QuerySingleAsync<int>(INSERT_CUSTOMER, new { personId = entity.PersonId }, transaction);
                transaction.Commit();
                return personId;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error could not persist customer {entity} in DataBase. Message was {ex.Message}", ex);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

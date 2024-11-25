using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Dapper.SqlMapper;
using ThirdSemesterProject.DAL.Authentication;
using ThirdSemesterProject.DAL.Model;

namespace ThirdSemesterProject.DAL.DAOs
{
    public class CustomerDAO : BaseDAO, ICustomerDAO
    {
        private readonly string INSERT_CUSTOMER = "INSERT INTO customer (person_id) VALUES (@PersonId)";
        private readonly string INSERT_PERSON = "INSERT INTO person (name, email, phone_no, password_hash, person_type, fk_address_id) VALUES (@Name, @Email, @PhoneNo, @PasswordHash, @PersonType, 1) SELECT CAST(SCOPE_IDENTITY() AS INT)";
        private readonly string INSERT_ADDRESS = "";
        private readonly string INSERT_ZIP_CITY = "";
        private readonly string GET_MAIL = "SELECT person_id, password_hash FROM person Where email = @email";
        public CustomerDAO(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<int> CreateAsync(Customer entity, string password)
        {
            using var connection = CreateConnection();
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var passwordHash = BCryptTool.HashPassword(password);
                //int addressId = await connection.ExecuteScalarAsync<int>(INSERT_ADDRESS, entity, transaction);
                int personId = await connection.ExecuteScalarAsync<int>(INSERT_PERSON, new { fk_address_id = 1, Name = entity.Name, Email = entity.Email, PhoneNo = entity.PhoneNO, PasswordHash = passwordHash, PersonType = "Customer"}, transaction );
                await connection.ExecuteAsync(INSERT_CUSTOMER, new { PersonId = personId }, transaction);
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

        public async Task<int> LoginAsync(string email, string password)
        {
            using var connection = CreateConnection();
            connection.Open();
            try
            {
                var customerTuple = await connection.QueryFirstOrDefaultAsync<PersonTuple>(GET_MAIL, new {email = email});
                if (customerTuple != null && BCryptTool.ValidatePassword(password, customerTuple.PasswordHash))
                {
                    return customerTuple.PersonId;
                }   
                return -1;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error Login in for Customer with email: {email}. Meassage was {ex.Message}", ex);
            }
        }

        public Task<bool> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

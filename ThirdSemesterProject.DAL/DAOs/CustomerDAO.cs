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
using System.Data.SqlClient;

namespace ThirdSemesterProject.DAL.DAOs
{
    public class CustomerDAO : BaseDAO, ICustomerDAO
    {
        private readonly string INSERT_CUSTOMER = "INSERT INTO customer (person_id) VALUES (@PersonId)";
        private readonly string INSERT_PERSON = "INSERT INTO person (name, email, phone_no, password_hash, person_type, fk_address_id) VALUES (@Name, @Email, @PhoneNo, @PasswordHash, @PersonType, @FKAddressId) SELECT CAST(SCOPE_IDENTITY() AS INT)";
        private readonly string INSERT_ADDRESS = "";
        private readonly string INSERT_ZIP_CITY = "";
        private readonly string GET_MAIL = "SELECT person_id as PersonId, password_hash as PasswordHash FROM person Where email = @email";
        private readonly string GET_CUSTROMER_BY_ID = "select person_id as PersonId, name as Name, email as Email, phone_no as PhoneNO, person_type as PersonType from person Where person_id = @id";
        private readonly string INSERT_INTO_ADDRESS = "insert into address (house_no, road_name, fk_zip) VALUES (@HouseNo, @RoadName, @FkZip) SELECT CAST(SCOPE_IDENTITY() as INT);";
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
                var addressIdToAdd = await connection.ExecuteScalarAsync<int>(INSERT_INTO_ADDRESS, new { HouseNo = entity.Address.HouseNo, RoadName = entity.Address.RoadName, FkZip = entity.Address.Zip, }, transaction);
                var passwordHash = BCryptTool.HashPassword(password);
                //int addressId = await connection.ExecuteScalarAsync<int>(INSERT_ADDRESS, entity, transaction);
                int personId = await connection.ExecuteScalarAsync<int>(INSERT_PERSON, new { FKAddressId = addressIdToAdd, Name = entity.Name, Email = entity.Email, PhoneNo = entity.PhoneNO, PasswordHash = passwordHash, PersonType = "Customer"}, transaction );
                await connection.ExecuteAsync(INSERT_CUSTOMER, new { PersonId = personId }, transaction);
                transaction.Commit();
                return personId;
            }
            catch (SqlException ex)
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

        public async Task<Customer> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            connection.Open();
            try
            {
                var customer = await connection.QuerySingleOrDefaultAsync<Customer>(GET_CUSTROMER_BY_ID, new { id });
                return customer;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error retrieving Customer with id: {id}. Meassage was {ex.Message}", ex);
            }
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

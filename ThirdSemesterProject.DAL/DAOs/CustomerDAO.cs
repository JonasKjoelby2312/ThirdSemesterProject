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
    /// <summary>
    /// Implementation of the ICustomerDAO interface
    /// </summary>
    public class CustomerDAO : BaseDAO, ICustomerDAO
    {
        private readonly string INSERT_CUSTOMER = "INSERT INTO customer (person_id) VALUES (@PersonId)";
        private readonly string INSERT_PERSON = "INSERT INTO person (name, email, phone_no, password_hash, person_type, fk_address_id) VALUES (@Name, @Email, @PhoneNo, @PasswordHash, @PersonType, @FKAddressId) SELECT CAST(SCOPE_IDENTITY() AS INT)";
        private readonly string GET_MAIL = "SELECT person_id as PersonId, password_hash as PasswordHash FROM person Where email = @email";
        private readonly string GET_CUSTROMER_BY_ID = "select person_id as PersonId, name as Name, email as Email, phone_no as PhoneNO, person_type as PersonType from person Where person_id = @id";
        private readonly string INSERT_INTO_ADDRESS = "insert into address (house_no, road_name, fk_zip) VALUES (@HouseNo, @RoadName, @FkZip) SELECT CAST(SCOPE_IDENTITY() as INT);";
        public CustomerDAO(string connectionstring) : base(connectionstring)
        {
        }

        //This method is used for creating customers on the webpage. 
        //The method takes a Customer object, and a password. 
        //The typed password is salted and hashed by the BCryptTool. 
        //The method returns the newly created customerId. 
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

        /// <summary>
        /// This method is used for getting a customer by ID.
        /// </summary>
        /// <param name="id">takes an id in the params.</param>
        /// <returns>A customer by givin id</returns>
        /// <exception cref="Exception">thros an exception if it fails with the id</exception>
        /// //SAMME SOM I TIDL. KLASSE
        public async Task<Customer> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            connection.Open();
            try
            {
                var customer = await connection.QuerySingleOrDefaultAsync<Customer>(GET_CUSTROMER_BY_ID, new { id });
                connection.Close();
                return customer;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error retrieving Customer with id: {id}. Meassage was {ex.Message}", ex);
            }
        }

        //This method is used for logging in to the webpage. 
        //The method takes an email and password in the params. 
        //The BCryptTool is used for salting and hashing the password from the user
        //And is checked against the salted and hashed password from the database. 
        //If the passwords and email matches the one in the database, 
        //The method returns the customerId, else it will return -1. 
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
                connection.Close(); 
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

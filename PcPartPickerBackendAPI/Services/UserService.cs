using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Repository;

namespace PcPartPickerBackendAPI.Services
{

    public class UserService : BaseRepository, IUserService
    {
        public UserService(IConfiguration configuration) : base(configuration)
        {
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = checkInvalidUser(username);

            // check if username exists
            if (user == null)
            {
                return null;
            }
            byte[] passHash = user.PasswordHash;
            byte[] passSalt = user.PasswordSalt;
             //check if password is correct
            if (!verifyPasswordHash(password, passHash, passSalt))
            {
                return null;
            }
            return user;
        }

        public User Create(User user, string password)
        {
            string query =
                $@"
                INSERT INTO pc.[user] (
                    firstname, 
                    lastname, 
                    username, 
                    email, 
                    passwordHash, 
                    passwordSalt
                )
                SELECT
                    @firstName,
                    @lastName,
                    @username,
                    @email,
                    @passwordHash,
                    @passwordSalt";

            // validation
            if (string.IsNullOrEmpty(password))
            {
                throw new ApplicationException("Password is required");
            }

            var existedUser = checkInvalidUser(user.UserName);

            if (existedUser != null)
            {
                throw new ApplicationException("Username \"" + user.UserName + "\" is already taken");
            }
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            Connection.Query<User>(query, new User { FirstName = user.FirstName, LastName = user.LastName, UserName = user.UserName, Email = user.Email, PasswordHash = user.PasswordHash, PasswordSalt = user.PasswordSalt });
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            string query =
                $@"
                SELECT id, firstname, lastname, username, email, passwordHash, passwordSalt
                FROM
                    pc.[user]
                WHERE
                    id = @id";
            var user = Connection.Query<User>(query, new { id }).SingleOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        // private helper methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private User checkInvalidUser(string username)
        {
            string query =
                $@"
                SELECT id, firstname, lastname, username, email, passwordHash, passwordSalt
                FROM
                    pc.[user]
                WHERE
                    username = @username";
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            var user = Connection.Query<User>(query, new { username }).SingleOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        private bool verifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }
            //if (storedHash.Length != 64)
            //{
            //    throw new ArgumentException("Invalid length of password hash(64 bytes expected).", "passwordHash");
            //}
            if (storedHash.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

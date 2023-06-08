using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using LogicLayer.Class;
using LogicLayer.Interface;

namespace LogicLayer.Services
{
    public class LogInService 
    {
        private IUserDataTraffic userDataTraffic;
        private const int keySize = 64;
        private const int iterations = 350000;
        private readonly static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;


        public LogInService(IUserDataTraffic userDataTraffic)
        {
            this.userDataTraffic = userDataTraffic
             ?? throw new ArgumentNullException(nameof(userDataTraffic));
        }
        public List<User> GetAllCostumers()
        {
            return userDataTraffic.GetAllCostumers();
        }
        public bool AddUser(User user)
        {
            return userDataTraffic.AddUser(user);
        }

        public User ValidateUserCredentials(string username, string password, string roleId)
        {
            List<User> users;

            if (roleId != null)
            {
                users = userDataTraffic.GetAllCostumers();
            }
            else
            {
                users = userDataTraffic.GetEmployees();
            }
                

            User user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && CreateHash(user.Salt, password) == user.HashedPassword)
            {
                return user;
            }
               

            return null;
        }

        public bool RegisterUser(int id, string firstName, string lastName, string username, string password, string email, string phoneNumber, string birthDate, string address, string roleId)
        {
            List<User> users;

            if (roleId == "2")
            {
                users = userDataTraffic.GetAllCostumers();
            }
            else
            {
                users = userDataTraffic.GetEmployees();
            }
               

            if (users.Any(u => u.Username == username))
            {
                return false;
            }
            (string salt, string hashedPassword) = CreateSaltAndHash(password);
            User user = new User(id, firstName, lastName, username, salt, hashedPassword, email, phoneNumber, birthDate, address, roleId);

            // Add the user to the data source
            return AddUser(user);
        }
        public static (string Salt, string HashedPassword) CreateSaltAndHash(string password)
        {
            byte[] salt_bytes = RandomNumberGenerator.GetBytes(keySize);
            string salt = Convert.ToHexString(salt_bytes);
            string hashedPassword = CreateHash(salt, password);
            return (salt, hashedPassword);
        }

        public static string CreateHash(string salt, string password)
        {
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Convert.FromHexString(salt),
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

    }
    }

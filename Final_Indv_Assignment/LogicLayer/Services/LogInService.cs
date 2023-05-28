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
        public List<User> GetAllUsers()
        {
            return userDataTraffic.GetAll();
        }
        public bool AddUser(User user)
        {
            return userDataTraffic.AddUser(user);
        }
        public User? ValidateUserCredentials(string username, string password)
        {

            List<User> users = new List<User>();
            
            users.AddRange(userDataTraffic.GetAll());
            User? matchedUser = null;

            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    // Hash the provided password using the salt stored in the user object

                    string hashedPassword = CreateHash(user.Salt, password);
                    // Compare the hashed password with the one stored in the user object
                    if (hashedPassword == user.HashedPassword)
                    {
                       //matchedUser = new User(user.FirstName, user.LastName, user.Username, user.Salt, user.HashedPassword, user.Email, user.PhoneNumber, user.BirthDate, user.Adress);
                        return user;
                    }
                }
            }
            return null;
        }
        public bool RegisterUser(int Id,string FirstName, string LastName, string Username, string Password, string Email, string PhoneNumber, string BirthDate, string Adress)
        {

            (string salt, string hashedPassword) = CreateSaltAndHash(Password);
            User user = new User(Id,FirstName, LastName, Username,salt, hashedPassword, Email, PhoneNumber, BirthDate, Adress);
                // Check if the user already exists in the data source
                if (userDataTraffic.GetAll().Any(u => u.Username == Username))
                {
                    return false; // User already exists, return false
                }

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

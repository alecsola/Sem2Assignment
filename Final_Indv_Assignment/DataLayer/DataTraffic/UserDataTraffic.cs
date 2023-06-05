using System.Data;
using DataLayer.DAL;
using DataLayer.DataConvertingToObject;
using LogicLayer.Class;
using LogicLayer.Interface;
using Microsoft.Data.SqlClient;

namespace DataLayer.DataTraffic
{
    public class UserDataTraffic : DataHandler, IUserDataTraffic
    {
        protected override string cmd
        {
            get
            {
                return "select u.UserId,u.Adress, u.DateOfBirth , u.Email, u.FirstName, u.LastName,u.Salt, u.HashedPassword, u.PhoneNumber, u.Username,u.RoleId from Users u";
            }
        }
        public List<User> GetAllCostumers()
        {
            List<User> Users = new List<User>();
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                Users.Add(DataConvertingUser.ConvertRowToUser(dr));
            }

            
            return Users;


        }
        public bool AddUser(User user)
        {
            string query = $"INSERT INTO Users ( FirstName, LastName, Username, Salt, HashedPassword, Email, Adress, DateOfBirth, PhoneNumber)  " +
                $"VALUES ('{user.FirstName}', '{user.LastName}', '{user.Username}','{user.Salt}','{user.HashedPassword}', '{user.Email}', '{user.Adress}', '{user.BirthDate}' , {user.PhoneNumber} );";
            return executeQuery(query) == 0 ? false : true;

        }
        public List<User> GetEmployees()
        {
            List<User> Users = new List<User>();
            string query = "select u.UserId,u.Adress, u.DateOfBirth , u.Email, u.FirstName, u.LastName,u.Salt, u.HashedPassword, u.PhoneNumber, u.Username,u.RoleId from Users u Where u.RoleId=1\r\n";
            DataTable table = base.ReadData(query);
            foreach (DataRow dr in table.Rows)
            {
                Users.Add(DataConvertingUser.ConvertRowToUser(dr));
            }
            return Users;
        }

        
        
    }
}
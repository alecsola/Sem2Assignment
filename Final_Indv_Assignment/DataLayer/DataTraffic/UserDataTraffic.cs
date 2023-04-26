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
                return "select u.Adress, u.DateOfBirth , u.Email, u.FirstName, u.LastName,u.Salt, u.HashedPassword, u.PhoneNumber, u.Username from Users u ";
            }
        }
        public List<User> GetAll()
        {
            List<User> Users = new List<User>();
            DataTable table = base.ReadData();
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

        
        
    }
}
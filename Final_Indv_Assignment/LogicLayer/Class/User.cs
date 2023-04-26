namespace LogicLayer.Class
{
    public class User
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
   


        //public User(string firstName, string lastName, string username, string password, string email, int phoneNumber, string birthDate, string adress)
        //{
        //    Username = username;
        //    Password = password;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    BirthDate = birthDate;
        //    Adress = adress;
        //    PhoneNumber = phoneNumber;

        //}
        public User(string firstName, string lastName, string username,string salt,string hashedPassword, string email, string phoneNumber, string birthDate, string adress)
        {
            Username = username;
            Salt = salt;
            HashedPassword = hashedPassword;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Adress = adress;
            PhoneNumber = phoneNumber;
          
        }

       
    }
}
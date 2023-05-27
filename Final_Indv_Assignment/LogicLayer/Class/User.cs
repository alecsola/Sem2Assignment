namespace LogicLayer.Class
{
    public class User
    {
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Salt { get; private set; }
        public string Password { get; private set; }
        public string HashedPassword { get; private set; }
        public string Email { get; private set; }
        public string Adress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string BirthDate { get; private set; }
   


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
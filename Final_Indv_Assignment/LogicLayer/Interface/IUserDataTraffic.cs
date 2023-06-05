using LogicLayer.Class;

namespace LogicLayer.Interface
{
    public interface IUserDataTraffic
    {
        bool AddUser(User user);
        List<User> GetAllCostumers();
        List<User> GetEmployees();


    }
}
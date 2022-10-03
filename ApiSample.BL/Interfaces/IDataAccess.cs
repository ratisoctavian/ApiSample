using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Models.DataModel;

namespace ApiSample.BL.Interfaces
{
    public interface IDataAccess
    {
        List<User> GetUsers();

        User CreateUser(string firstName, string lastName, string loginName, string email, string phoneNumber, string userTyper);

        User? UpdateUser(string firstName, string lastName, string loginName, string email, string phoneNumber, string userType);

        User? DeleteUser(string loginName);

        User? ReadUser(string loginName);

        User? GetUserByLoginName(string loginName);
    }
}

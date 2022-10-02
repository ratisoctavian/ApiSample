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

        long CreateUser(User user);

        long UpdateUser(User user);

        bool DeleteUser(long id);

        User ReadUser(User user);
    }
}

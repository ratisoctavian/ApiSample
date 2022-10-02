using ApiSample.BL.Interfaces;
using ApiSample.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Access
{
    public class MockDataAccess : IDataAccess
    {

        public List<User> Users { get; set; }

        public MockDataAccess()
        {
            Users = new List<User>();
            Users.Add(new User {Id=1, Email = "astig@astig.com", FirstName = "Astig", LastName = "Basca", LoginName = "Astig", PhoneNumber = "1234" });
            Users.Add(new User {Id=2, Email = "tavi@tavi.com", FirstName = "Tavo", LastName = "Ratis", LoginName = "Tavi", PhoneNumber = "4321" });

        }

        public long CreateUser(User user)
        {
            Users.Add(user);
            return user.Id;
        }

        public bool DeleteUser(long id)
        {
            var userToDelete = Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete is null)
            {
                return false;
            }
            else
            {
                Users.Remove(userToDelete);
                return true;
            }
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public User? ReadUser(User user)
        {
            return Users.FirstOrDefault(u => u.Id == user.Id);
        }

        public long UpdateUser(User user)
        {

            var userToUpdate = Users.FirstOrDefault(u => u.Id == user.Id);
            userToUpdate = user;
            return user.Id;
        }
    }
}

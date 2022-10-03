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

        public User CreateUser(string firstName, string lastName, string loginName, string email, string phoneNumber, string userTyper)
        {
            var user = new User() { Email = email, FirstName = firstName, LastName = lastName, LoginName = loginName, PhoneNumber = phoneNumber };
            user.Id = Users.Max(u => u.Id) + 1;
            Users.Add(user);
            return user;
        }

        public User? DeleteUser(string loginName)
        {
            var userToDelete = Users.FirstOrDefault(u => u.LoginName == loginName);
            if (userToDelete is null)
            {
                return null;
            }
            else
            {
                Users.Remove(userToDelete);
                return userToDelete;
            }
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public User? ReadUser(string loginName)
        {
            return Users.FirstOrDefault(u => u.LoginName == loginName);
        }

        public User? UpdateUser(string firstName, string lastName, string loginName, string email, string phoneNumber, string userTyper)
        {

            var userToUpdate = Users.FirstOrDefault(u => u.LoginName == loginName);
            if (userToUpdate is not null)
            {
                userToUpdate.UserTypes = userTyper;
                userToUpdate.Email = email;
                userToUpdate.PhoneNumber = phoneNumber;
                userToUpdate.FirstName = firstName;
                userToUpdate.LastName = lastName;
                userToUpdate.LoginName = loginName;
            }

            return userToUpdate;
        }
    }
}

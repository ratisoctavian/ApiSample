using ApiSample.BL.Interfaces;
using ApiSample.Models.DataModel;
using ApiSample.Models.Enums;
using Microsoft.Extensions.Logging;
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
            Users.Add(new User {Email = "astig@astig.com", FirstName = "Astig", LastName = "Basca", LoginName = "Astig", PhoneNumber = "1234" });
            Users.Add(new User {Email = "tavi@tavi.com", FirstName = "Tavi", LastName = "Ratis", LoginName = "Tavi", PhoneNumber = "4321" });
        }

        public User CreateUser(string firstName, string lastName, string loginName, string email, string phoneNumber, UserTypes userTyper)
        {
            var user = new User() { Email = email, FirstName = firstName, LastName = lastName, LoginName = loginName, PhoneNumber = phoneNumber };
            if (Users.Any(u => u.LoginName.ToLower() == loginName.ToLower()))
            {
                throw new Exception("LoginName already exists");
            }
            Users.Add(user);
            return user;
        }

        public User? DeleteUser(string loginName)
        {
            var userToDelete = Users.FirstOrDefault(u => u.LoginName.ToLower() == loginName.ToLower());
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
            return Users.FirstOrDefault(u => u.LoginName.ToLower() == loginName.ToLower());
        }

        public User? UpdateUser(string firstName, string lastName, string loginName, string email, string phoneNumber, UserTypes userType)
        {

            var userToUpdate = Users.FirstOrDefault(u => u.LoginName.ToLower() == loginName.ToLower());
            if (userToUpdate is not null)
            {
                userToUpdate.UserType = userType;
                userToUpdate.Email = email;
                userToUpdate.PhoneNumber = phoneNumber;
                userToUpdate.FirstName = firstName;
                userToUpdate.LastName = lastName;
                userToUpdate.LoginName = loginName;
            }

            return userToUpdate;
        }

        public User? GetUserByLoginName(string loginName)
        {
            return Users.FirstOrDefault(u => u.LoginName.ToLower()==loginName.ToLower());
        }
    }
}

using ApiSample.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Models.DataModel
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        
        public string FirstName { get; set; }    
        
        public string LastName { get; set; }

        public string LoginName { get; set; }

        public string Email { get; set; }   

        public string PhoneNumber { get; set; }

        public UserTypes UserType {  get; set; }
    }
}

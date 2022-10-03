using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Models.DataModel
{
    public class User
    {

        public long Id {  get; set; }
        
        public string FirstName { get; set; }    
        
        public string LastName { get; set; }

        public string LoginName { get; set; }

        public string Email { get; set; }   

        public string PhoneNumber { get; set; }

        public string UserTypes {  get; set; }
    }
}

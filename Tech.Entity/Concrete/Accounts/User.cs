using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.Entity.Concrete.Accounts
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        
        public ICollection<Role> Roles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.DataAccess.Abstract.Account;
using Tech.DataAccess.Concrete.EntityFrameworkRepositories.Commons;
using Tech.DataAccess.EntityFrameworks.Contexts;
using Tech.Entity.Concrete.Accounts;

namespace Tech.DataAccess.Concrete.EntityFrameworkRepositories.Accounts
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        public AuthRepository(TechContext dbContext) : base(dbContext)
        {
        }

      
    }
}

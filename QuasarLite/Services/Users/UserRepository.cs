using QuasarLite.DbContexts;
using QuasarLite.Models;
using QuasarLite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuasarLite.Services.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly XContext _xContext;

        public UserRepository(XContext xContext) : base(xContext)
        {
            _xContext = xContext;
        }

        public User FindUsername(string username)
        {
            return _xContext.Set<User>().FirstOrDefault(a => a.Username == username);
        }
    }
}

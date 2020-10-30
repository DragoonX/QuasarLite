using QuasarLite.DbContexts;
using QuasarLite.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuasarLite.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XContext _xContext;

        public UnitOfWork(XContext xContext)
        {
            _xContext = xContext;
            userRepository = new UserRepository(_xContext);
        }

        public IUserRepository userRepository { get; set; }

        public int Complete()
        {
            return _xContext.SaveChanges();
        }

        public void Dispose()
        {
            _xContext.Dispose();
        }
    }
}

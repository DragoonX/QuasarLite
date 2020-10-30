using System;

namespace QuasarLite.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; set; }
        int Complete();
    }
}

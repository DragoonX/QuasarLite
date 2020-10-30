using QuasarLite.Models;

namespace QuasarLite.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUsername(string username);
    }

}

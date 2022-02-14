using V8.Domain.Interfaces.V8;
using V8.Domain.Models.V8;
using V8.Infrastructure.Contexts;

namespace V8.Infrastructure.Repositories.V8
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(V8Context repositoryContext) : base(repositoryContext)
        {
        }
    }
}

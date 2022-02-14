using System.Threading.Tasks;

namespace V8.Domain.Interfaces.V8
{
    public interface IV8RepositoryWrapper
    {
        #region Properties V8
        IUserRepository User { get; }
        #endregion
        Task SaveAync();
    }
}

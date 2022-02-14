using System.Collections.Generic;
using System.Threading.Tasks;

namespace V8Hangfire.Application.Interfaces
{
    public interface IBaseMasterService<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> Gets();

        Task<TEntity> Get(object id);

        Task<bool> Create(TEntity model);

        Task<bool> Update(TEntity model);

        Task<bool> Delete(object id);
    }
}

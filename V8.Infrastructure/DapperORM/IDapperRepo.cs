using System.Data;

namespace V8.Infrastructure.DapperORM
{
    public interface IDapperRepo
    {
        public IDbConnection idbConnection { get; }
    }
}

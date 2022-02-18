using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace V8.Infrastructure.Repositories.Dapper
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName connectionName);
    }
}

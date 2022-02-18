using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace V8.Infrastructure.Repositories.Dapper
{
    public class V8DapperRepo : DapperRepo, IV8DapperRepo
    {
        public V8DapperRepo(IConfiguration configuration, IDbConnectionFactory dbConnection)
        : base(configuration, dbConnection.CreateDbConnection(DatabaseConnectionName.V8Connection))
        {

        }
    }
}

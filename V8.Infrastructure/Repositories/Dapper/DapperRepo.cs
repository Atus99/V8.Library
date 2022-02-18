using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using V8.Infrastructure.DapperORM;

namespace V8.Infrastructure.Repositories.Dapper
{
    public abstract class DapperRepo : IDapperRepo
    {
        protected readonly IConfiguration _configuration;
        protected readonly IDbConnection _dbConnection;

        public DapperRepo(IConfiguration configuration, IDbConnection dbConnection)
        {
            _configuration = configuration;
            this._dbConnection = dbConnection;
        }

        public IDbConnection idbConnection
        {
            get
            {
                return _dbConnection;
            }
        }
    }
}

﻿using System.Collections.Generic;
using System.Data.SqlClient;

namespace Challenge.Nubimetrics.Infrastructure.Data.Contracts
{
    public interface IQueryManager
    {
        string Query { get; }
        SqlParameter[] Parameters { get; }

        void GenerateQuery(SqlCommandTypeInvocation typeInvocation, string name, IDictionary<string, object> parameters);
    }
}

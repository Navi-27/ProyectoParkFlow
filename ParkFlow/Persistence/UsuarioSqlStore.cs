using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class UsuarioSqlStore : SqlDataStore<Usuario, int>
    {
        protected override string SelectSql => throw new NotImplementedException();

        protected override string UpsertSql => throw new NotImplementedException();

        protected override string DeleteSql => throw new NotImplementedException();

        protected override Usuario Map(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        protected override void SetParameters(MySqlCommand cmd, Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}

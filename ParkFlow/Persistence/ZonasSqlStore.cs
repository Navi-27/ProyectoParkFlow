using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class ZonasSqlStore : SqlDataStore<Zona, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_zona, nombre, ancho, largo FROM zona";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO zona
                    (id_zona, nombre, ancho, largo)
                    VALUES
                    (@id, @nombre, @ancho, @largo)
                    ON DUPLICATE KEY UPDATE
                    nombre = @nombre, ancho = @ancho, largo = @largo;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM zona WHERE id_zona = @id; ";
            }
        }

        protected override Zona Map(MySqlDataReader reader)
        {
            Zona zona = Zona.Create();

            zona.Id = reader.GetInt32(reader.GetOrdinal("id_zona"));
            zona.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            zona.Ancho = reader.GetDouble(reader.GetOrdinal("ancho"));
            zona.Largo = reader.GetDouble(reader.GetOrdinal("largo"));

            return zona;
        }

        protected override void SetParameters(MySqlCommand cmd, Zona z)
        {
            cmd.Parameters.AddWithValue("@id", z.Id);
            cmd.Parameters.AddWithValue("@nombre", z.Nombre);
            cmd.Parameters.AddWithValue("@ancho", z.Ancho);
            cmd.Parameters.AddWithValue("@largo", z.Largo);
        }
    }
}

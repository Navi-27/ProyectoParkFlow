using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class RegistroSqlStore : SqlDataStore<Registro, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_registro, persona_visitante, persona_visitada, vivienda_id_vivienda, fecha_ingreso, fecha_salida FROM registro";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO registro
                    (id_registro, persona_visitante, persona_visitada, vivienda_id_vivienda, fecha_ingreso, fecha_salida)
                    VALUES
                    (@id, @personaVisitante, @personaVisitada, @idVivienda, @fechaIngreso, @fechaSalida)
                    ON DUPLICATE KEY UPDATE
                    id_registro = @id, persona_visitante = @personaVisitante, persona_visitada = @personaVisitada,
                    vivienda_id_vivienda = @idVivienda, fecha_ingreso = @fechaIngreso, fecha_salida = @fechaSalida;";
            }
        }

        protected override string DeleteSql 
        {
            get
            {
                return " DELETE FROM registro WHERE id_registro = @id;";
            }
        }

        protected override Registro Map(MySqlDataReader reader)
        {
            Registro registro = Registro.Create();
            registro.Id = reader.GetInt32(reader.GetOrdinal("id_registro"));
            registro.PersonaVisitante = reader.GetString(reader.GetOrdinal("persona_visitante"));
            registro.PersonaVisitada = reader.GetString(reader.GetOrdinal("persona_visitada"));
            registro.IdVivienda = reader.GetInt32(reader.GetOrdinal("vivienda_id_vivienda"));
            registro.FechaIngreso = reader.GetDateTime(reader.GetOrdinal("fecha_ingreso"));

            int posSalida = reader.GetOrdinal("fecha_salida");
            registro.FechaSalida = reader.IsDBNull(posSalida) ? null : reader.GetDateTime(posSalida);

            return registro;
        }

        protected override void SetParameters(MySqlCommand cmd, Registro registro)
        {
            cmd.Parameters.AddWithValue("@id", registro.Id);
            cmd.Parameters.AddWithValue("@personaVisitante", registro.PersonaVisitante);
            cmd.Parameters.AddWithValue("@personaVisitada", registro.PersonaVisitada);
            cmd.Parameters.AddWithValue("@idVivienda", registro.IdVivienda);
            cmd.Parameters.AddWithValue("@fechaIngreso", registro.FechaIngreso);
            cmd.Parameters.AddWithValue("@fechaSalida", (object?)registro.FechaSalida ?? DBNull.Value);
        }
    }
}

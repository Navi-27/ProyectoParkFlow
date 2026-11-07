using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class RegistroSqlStore : SqlDataStore<Registro, int> //Load reibe datareader carag toda la tabla de una vez 
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

        // Convierte una fila de la base en un Registro
        protected override Registro Map(MySqlDataReader reader)
        {
            Registro registro = Registro.Create();
            registro.Id = reader.GetInt32(reader.GetOrdinal("id_registro"));
            registro.PersonaVisitante = reader.GetString(reader.GetOrdinal("persona_visitante"));
            registro.PersonaVisitada = reader.GetString(reader.GetOrdinal("persona_visitada"));
            registro.IdVivienda = reader.GetInt32(reader.GetOrdinal("vivienda_id_vivienda"));
            registro.FechaIngreso = reader.GetDateTime(reader.GetOrdinal("fecha_ingreso"));

            // Esta columna puede ser NULL en la base

            int posSalida = reader.GetOrdinal("fecha_salida");
            registro.FechaSalida = reader.IsDBNull(posSalida) ? null : reader.GetDateTime(posSalida);


            return registro;
        }

        protected override void SetParameters(MySqlCommand cmd, Registro entity)
        {
            cmd.Parameters.AddWithValue("@id", r.Id);
            cmd.Parameters.AddWithValue("@visitante", r.PersonaVisitante);
            cmd.Parameters.AddWithValue("@visitada", r.PersonaVisitada);
            cmd.Parameters.AddWithValue("@vivienda", r.IdVivienda);
            cmd.Parameters.AddWithValue("@ingreso", r.FechaIngreso);
            cmd.Parameters.AddWithValue("@salida", (object?)r.FechaSalida ?? DBNull.Value);
        }
    }
}

using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class ParqueaderoSqlStore : SqlDataStore<Parqueadero, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_parqueo, id_zona, persona_documento, vehiculo_placa, codigo, nivel, coord_x, coord_y, tipo FROM parqueo";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO parqueo
                    (id_parqueo, id_zona, persona_documento, vehiculo_placa, codigo, nivel, coord_x, coord_y, tipo)
                    VALUES
                    (@id, @zona, @persona, @placa, @codigo, @nivel, @x, @y, @tipo)
                    ON DUPLICATE KEY UPDATE
                    id_zona = @zona, persona_documento = @persona, vehiculo_placa = @placa,
                    codigo = @codigo, nivel = @nivel, coord_x = @x,
                    coord_y = @y, tipo = @tipo;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM parqueo WHERE id_parqueo = @id;";
            }
        }

        protected override Parqueadero Map(MySqlDataReader reader)
        {
            Parqueadero parqueadero = Parqueadero.Create();

            parqueadero.Id = reader.GetInt32(reader.GetOrdinal("id_parqueo"));
            parqueadero.IdZona = reader.GetInt32(reader.GetOrdinal("id_zona"));
            parqueadero.Codigo = reader.GetString(reader.GetOrdinal("codigo"));
            parqueadero.Nivel = reader.GetInt32(reader.GetOrdinal("nivel"));
            parqueadero.CoordX = reader.GetDouble(reader.GetOrdinal("coord_x"));
            parqueadero.CoordY = reader.GetDouble(reader.GetOrdinal("coord_y"));
            parqueadero.Tipo = reader.GetString(reader.GetOrdinal("tipo"));

            int posPersona = reader.GetOrdinal("persona_documento");
            parqueadero.PersonaDocumento = reader.IsDBNull(posPersona) ? string.Empty : reader.GetString(posPersona);

            int posPlaca = reader.GetOrdinal("vehiculo_placa");
            parqueadero.VehiculoPlaca = reader.IsDBNull(posPlaca) ? string.Empty : reader.GetString(posPlaca);

            return parqueadero;
        }

        protected override void SetParameters(MySqlCommand cmd, Parqueadero p)
        {
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@zona", p.IdZona);
            cmd.Parameters.AddWithValue("@codigo", p.Codigo);
            cmd.Parameters.AddWithValue("@nivel", p.Nivel);
            cmd.Parameters.AddWithValue("@x", p.CoordX);
            cmd.Parameters.AddWithValue("@y", p.CoordY);
            cmd.Parameters.AddWithValue("@tipo", p.Tipo);
            cmd.Parameters.AddWithValue("@persona",
                string.IsNullOrEmpty(p.PersonaDocumento) ? DBNull.Value : p.PersonaDocumento);
            cmd.Parameters.AddWithValue("@placa",
                string.IsNullOrEmpty(p.VehiculoPlaca) ? DBNull.Value : p.VehiculoPlaca);
        }

    }
}

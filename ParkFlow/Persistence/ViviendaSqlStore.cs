using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class ViviendaSqlStore : SqlDataStore<Vivienda, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_vivienda, persona_documento, torre, piso, apartamento FROM vivienda";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO vivienda
                    (id_vivienda, persona_documento, torre, piso, apartamento)
                    VALUES
                    (@id, @persona, @torre, @piso, @apartamento)
                    ON DUPLICATE KEY UPDATE
                    persona_documento = @persona, torre = @torre,
                    piso = @piso, apartamento = @apartamento;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM vivienda WHERE id_vivienda = @id;";
            }
        }

        protected override Vivienda Map(MySqlDataReader reader)
        {
            Vivienda vivienda = Vivienda.Create();

            vivienda.Id = reader.GetInt32(reader.GetOrdinal("id_vivienda"));
            vivienda.PersonaDocumento = reader.GetString(reader.GetOrdinal("persona_documento"));
            vivienda.Torre = reader.GetString(reader.GetOrdinal("torre"));
            vivienda.Piso = reader.GetInt32(reader.GetOrdinal("piso"));
            vivienda.Apartamento = reader.GetInt32(reader.GetOrdinal("apartamento"));

            return vivienda; 
        }

        protected override void SetParameters(MySqlCommand cmd, Vivienda v)
        {
            cmd.Parameters.AddWithValue("@id", v.Id);
            cmd.Parameters.AddWithValue("@persona", v.PersonaDocumento);
            cmd.Parameters.AddWithValue("@torre", v.Torre);
            cmd.Parameters.AddWithValue("@piso", v.Piso);
            cmd.Parameters.AddWithValue("@apartamento", v.Apartamento);
        }
    }
}

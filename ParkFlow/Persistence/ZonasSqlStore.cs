using MySqlConnector;
using ParkFlow.DynamicStructure;
using ParkFlow.Logica;
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

        // Además de las zonas, lee sus vértices (segunda consulta a zona_vertice)
        public override IEnumerable<Zona> LoadAll()
        {
            Lista<Zona> zonas = new Lista<Zona>(base.LoadAll());

            try
            {
                CargarVertices(zonas);
            }
            catch (MySqlException ex) when (ex.ErrorCode == MySqlErrorCode.NoSuchTable)
            {
                // Todavía no se corrió db/migracion_zona_vertice.sql: las zonas usan ancho × largo
            }

            return zonas;
        }

        private static void CargarVertices(Lista<Zona> zonas)
        {
            using (MySqlConnection con = Database.CreateConnection())
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT id_zona, x, y FROM zona_vertice ORDER BY id_zona, orden", con))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idZona = reader.GetInt32(reader.GetOrdinal("id_zona"));
                        Zona? zona = zonas.FirstOrDefault(z => z.Id == idZona);
                        if (zona == null) continue;

                        zona.Vertices.Add(new Punto(
                            reader.GetDouble(reader.GetOrdinal("x")),
                            reader.GetDouble(reader.GetOrdinal("y"))));
                    }
                }
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

using MySqlConnector;
using ParkFlow.models;

namespace ParkFlow.Persistence
{
    internal class NodoRutaSqlStore : SqlDataStore<NodoRuta, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_nodo, nombre, tipo, coord_x, coord_y, id_parqueo FROM nodo_ruta";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO nodo_ruta
                    (id_nodo, nombre, tipo, coord_x, coord_y, id_parqueo)
                    VALUES
                    (@id, @nombre, @tipo, @x, @y, @parqueo)
                    ON DUPLICATE KEY UPDATE
                    nombre = @nombre, tipo = @tipo, coord_x = @x,
                    coord_y = @y, id_parqueo = @parqueo;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM nodo_ruta WHERE id_nodo = @id;";
            }
        }

        protected override NodoRuta Map(MySqlDataReader reader)
        {
            NodoRuta nodo = NodoRuta.Create();

            nodo.Id = reader.GetInt32(reader.GetOrdinal("id_nodo"));
            nodo.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            nodo.Tipo = reader.GetString(reader.GetOrdinal("tipo"));
            nodo.CoordX = reader.GetDouble(reader.GetOrdinal("coord_x"));
            nodo.CoordY = reader.GetDouble(reader.GetOrdinal("coord_y"));

            int posParqueo = reader.GetOrdinal("id_parqueo");
            nodo.IdParqueo = reader.IsDBNull(posParqueo) ? null : reader.GetInt32(posParqueo);

            return nodo;
        }

        protected override void SetParameters(MySqlCommand cmd, NodoRuta n)
        {
            cmd.Parameters.AddWithValue("@id", n.Id);
            cmd.Parameters.AddWithValue("@nombre", n.Nombre);
            cmd.Parameters.AddWithValue("@tipo", n.Tipo);
            cmd.Parameters.AddWithValue("@x", n.CoordX);
            cmd.Parameters.AddWithValue("@y", n.CoordY);
            cmd.Parameters.AddWithValue("@parqueo", n.IdParqueo.HasValue ? n.IdParqueo.Value : DBNull.Value);
        }
    }
}

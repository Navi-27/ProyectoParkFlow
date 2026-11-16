using MySqlConnector;
using ParkFlow.models;

namespace ParkFlow.Persistence
{
    internal class AristaRutaSqlStore : SqlDataStore<AristaRuta, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_arista, nodo_origen, nodo_destino, distancia, bidireccional FROM arista_ruta";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO arista_ruta
                    (id_arista, nodo_origen, nodo_destino, distancia, bidireccional)
                    VALUES
                    (@id, @origen, @destino, @distancia, @bidireccional)
                    ON DUPLICATE KEY UPDATE
                    nodo_origen = @origen, nodo_destino = @destino,
                    distancia = @distancia, bidireccional = @bidireccional;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM arista_ruta WHERE id_arista = @id;";
            }
        }

        protected override AristaRuta Map(MySqlDataReader reader)
        {
            AristaRuta arista = AristaRuta.Create();

            arista.Id = reader.GetInt32(reader.GetOrdinal("id_arista"));
            arista.NodoOrigen = reader.GetInt32(reader.GetOrdinal("nodo_origen"));
            arista.NodoDestino = reader.GetInt32(reader.GetOrdinal("nodo_destino"));
            arista.Distancia = reader.GetDouble(reader.GetOrdinal("distancia"));
            arista.Bidireccional = reader.GetBoolean(reader.GetOrdinal("bidireccional"));

            return arista;
        }

        protected override void SetParameters(MySqlCommand cmd, AristaRuta a)
        {
            cmd.Parameters.AddWithValue("@id", a.Id);
            cmd.Parameters.AddWithValue("@origen", a.NodoOrigen);
            cmd.Parameters.AddWithValue("@destino", a.NodoDestino);
            cmd.Parameters.AddWithValue("@distancia", a.Distancia);
            cmd.Parameters.AddWithValue("@bidireccional", a.Bidireccional);
        }
    }
}

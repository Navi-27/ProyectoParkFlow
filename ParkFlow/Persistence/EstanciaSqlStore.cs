using MySqlConnector;
using ParkFlow.models;

namespace ParkFlow.Persistence
{
    internal class EstanciaSqlStore : SqlDataStore<Estancia, int>
    {
        protected override string SelectSql
        {
            get 
            { 
                return "SELECT id_estancia, vehiculo_placa, id_parqueo, fecha_llegada, fecha_ocupacion, fecha_salida FROM estancia ORDER BY fecha_llegada"; 
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO estancia
                    (id_estancia, vehiculo_placa, id_parqueo, fecha_llegada, fecha_ocupacion, fecha_salida)
                    VALUES
                    (@id, @placa, @parqueo, @llegada, @ocupacion, @salida)
                    ON DUPLICATE KEY UPDATE
                    vehiculo_placa = @placa, id_parqueo = @parqueo, fecha_llegada = @llegada,
                    fecha_ocupacion = @ocupacion, fecha_salida = @salida;";
            }
        }

        protected override string DeleteSql
        {
            get { return "DELETE FROM estancia WHERE id_estancia = @id"; }
        }

        // Convierte una fila de la base en un Estancia
        protected override Estancia Map(MySqlDataReader reader)
        {
            Estancia estancia = Estancia.Create();
            estancia.Id = reader.GetInt32(reader.GetOrdinal("id_estancia"));
            estancia.VehiculoPlaca = reader.GetString(reader.GetOrdinal("vehiculo_placa"));
            estancia.FechaLlegada = reader.GetDateTime(reader.GetOrdinal("fecha_llegada"));

            // Estas tres columnas pueden ser NULL en la base
            int posParqueo = reader.GetOrdinal("id_parqueo");
            estancia.IdParqueadero = reader.IsDBNull(posParqueo) ? null : reader.GetInt32(posParqueo);

            int posOcupacion = reader.GetOrdinal("fecha_ocupacion");
            estancia.FechaOcupacion = reader.IsDBNull(posOcupacion) ? null : reader.GetDateTime(posOcupacion);

            int posSalida = reader.GetOrdinal("fecha_salida");
            estancia.FechaSalida = reader.IsDBNull(posSalida) ? null : reader.GetDateTime(posSalida);

            return estancia;
        }

        // Llena los parámetros del SQL con los datos de la entidad
        protected override void SetParameters(MySqlCommand cmd, Estancia e)
        {
            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@placa", e.VehiculoPlaca);
            cmd.Parameters.AddWithValue("@parqueo", (object?)e.IdParqueadero ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@llegada", e.FechaLlegada);
            cmd.Parameters.AddWithValue("@ocupacion", (object?)e.FechaOcupacion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@salida", (object?)e.FechaSalida ?? DBNull.Value);
        }

    }
}
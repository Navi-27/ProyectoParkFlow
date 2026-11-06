using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class VehiculosSqlStore : SqlDataStore<Vehiculo, string>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT placa,tipo_vehiculo, persona_documento, modelo, marca FROM vehiculo";
            }
        }

        protected override string UpsertSql 
        {
            get
            {
                return @"INSERT INTO vehiculo
                    (placa,tipo_vehiculo, persona_documento, modelo, marca)
                    VALUES
                    (@placa, @tipo, @persona, @modelo, @marca)
                    ON DUPLICATE KEY UPDATE
                    placa = @placa, tipo_vehiculo = @tipo, persona_documento = @persona,
                    modelo = @modelo, marca = @marca;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM vehiculo WHERE placa = @id;";
            }
        }

        // Convierte una fila de la base en un Vehiculo
        protected override Vehiculo Map(MySqlDataReader reader)
        {
            Vehiculo vehiculo;
            string tipo = reader.GetString(reader.GetOrdinal("tipo_vehiculo"));

            if (tipo.ToUpper() == "CARRO")
            {
                vehiculo = Carro.Create();
            }
            else
            {
                vehiculo = Moto.Create();
            }
            vehiculo.Id = reader.GetString(reader.GetOrdinal("placa"));
            vehiculo.PersonaDocumento = reader.GetString(reader.GetOrdinal("persona_documento"));
            vehiculo.Modelo = reader.GetString(reader.GetOrdinal("modelo"));
            vehiculo.Marca = reader.GetString(reader.GetOrdinal("marca"));

            return vehiculo;
        }

        // Llena los parámetros del SQL con los datos de la entidad
        protected override void SetParameters(MySqlCommand cmd, Vehiculo v)
        {
            cmd.Parameters.AddWithValue("@placa", v.Id);
            cmd.Parameters.AddWithValue("@tipo", v.Tipo());
            cmd.Parameters.AddWithValue("@persona", v.PersonaDocumento);
            cmd.Parameters.AddWithValue("@modelo", v.Modelo);
            cmd.Parameters.AddWithValue("@marca", v.Marca);
        }

    }
}

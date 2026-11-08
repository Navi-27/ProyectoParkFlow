using MySqlConnector;
using ParkFlow.models;

namespace ParkFlow.Persistence
{
    internal class PersonaSqlStore : SqlDataStore<Persona, string>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT documento, tipo_documento, nombre, apellido, movilidad_reducida, telefono, correo, tipo_persona FROM persona";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO persona
                    (documento, tipo_documento, nombre, apellido, movilidad_reducida, telefono, correo, tipo_persona)
                    VALUES
                    (@documento, @tipoDocumento, @nombre, @apellido, @movilidad, @telefono, @correo, @tipoPersona)
                    ON DUPLICATE KEY UPDATE
                    tipo_documento = @tipoDocumento, nombre = @nombre, apellido = @apellido,
                    movilidad_reducida = @movilidad, telefono = @telefono, correo = @correo,
                    tipo_persona = @tipoPersona;";
            }
        }

        protected override string DeleteSql
        {
            get 
            { 
                return "DELETE FROM persona WHERE documento = @id";
            }
        }

        protected override Persona Map(MySqlDataReader reader)
        {
            string tipo = reader.GetString(reader.GetOrdinal("tipo_persona"));

            Persona persona = tipo.ToUpper() switch
            {
                "RESIDENTE" => Residente.Create(),
                "VISITANTE" => Visitante.Create(),
                "EMPLEADO" => Empleado.Create(),
                _ => throw new InvalidOperationException($"Tipo de persona desconocido: {tipo}")
            };

            persona.Id = reader.GetString(reader.GetOrdinal("documento"));
            persona.TipoDocumento = reader.GetString(reader.GetOrdinal("tipo_documento"));
            persona.Nombre = reader.GetString(reader.GetOrdinal("nombre"));
            persona.Apellido = reader.GetString(reader.GetOrdinal("apellido"));
            persona.MovilidadReducida = reader.GetBoolean(reader.GetOrdinal("movilidad_reducida"));
            persona.Telefono = reader.GetString(reader.GetOrdinal("telefono"));

            int posCorreo = reader.GetOrdinal("correo");
            persona.Correo = reader.IsDBNull(posCorreo) ? string.Empty : reader.GetString(posCorreo);

            return persona;
        }

        protected override void SetParameters(MySqlCommand cmd, Persona p)
        {
            cmd.Parameters.AddWithValue("@documento", p.Id);
            cmd.Parameters.AddWithValue("@tipoDocumento", p.TipoDocumento);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);
            cmd.Parameters.AddWithValue("@movilidad", p.MovilidadReducida);
            cmd.Parameters.AddWithValue("@telefono", p.Telefono);
            cmd.Parameters.AddWithValue("@correo",string.IsNullOrWhiteSpace(p.Correo) ? DBNull.Value : p.Correo);
            cmd.Parameters.AddWithValue("@tipoPersona", TipoPersona(p));
        }

        private static string TipoPersona(Persona p)
        {
            return p switch
            {
                Residente => "RESIDENTE",
                Visitante => "VISITANTE",
                Empleado => "EMPLEADO",
                _ => throw new InvalidOperationException($"Tipo de persona no soportado: {p.GetType().Name}")
            };
        }
    }
}
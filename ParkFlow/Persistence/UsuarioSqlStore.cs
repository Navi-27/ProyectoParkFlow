using MySqlConnector;
using ParkFlow.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Persistence
{
    internal class UsuarioSqlStore : SqlDataStore<Usuario, int>
    {
        protected override string SelectSql
        {
            get
            {
                return "SELECT id_usuario, persona_documento, usuario, password, rol FROM usuario";
            }
        }

        protected override string UpsertSql
        {
            get
            {
                return @"INSERT INTO usuario
                    (id_usuario, persona_documento, usuario, password, rol)
                    VALUES
                    (@id, @persona, @usuario, @password, @rol)
                    ON DUPLICATE KEY UPDATE
                    persona_documento = @persona, usuario = @usuario,
                    password = @password, rol = @rol;";
            }
        }

        protected override string DeleteSql
        {
            get
            {
                return "DELETE FROM usuario WHERE id_usuario = @id;";
            }
        }

        // Convierte una fila de la base en un Usuario
        protected override Usuario Map(MySqlDataReader reader)
        {
            Usuario usuario = Usuario.Create();

            usuario.Id = reader.GetInt32(reader.GetOrdinal("id_usuario"));
            usuario.PersonaDocumento = reader.GetString(reader.GetOrdinal("persona_documento"));
            usuario.NombreUsuario = reader.GetString(reader.GetOrdinal("usuario"));
            usuario.Password = reader.GetString(reader.GetOrdinal("password"));
            // En la base el rol es 'ADMIN' o 'PORTERO'
            usuario.Rol = Enum.Parse<RolUsuario>(reader.GetString(reader.GetOrdinal("rol")), ignoreCase: true);

            return usuario;
        }

        // Llena los parámetros del SQL con los datos de la entidad
        protected override void SetParameters(MySqlCommand cmd, Usuario u)
        {
            cmd.Parameters.AddWithValue("@id", u.Id);
            cmd.Parameters.AddWithValue("@persona", u.PersonaDocumento);
            cmd.Parameters.AddWithValue("@usuario", u.NombreUsuario);
            cmd.Parameters.AddWithValue("@password", u.Password);
            cmd.Parameters.AddWithValue("@rol", u.Rol.ToString().ToUpper());
        }
    }
}

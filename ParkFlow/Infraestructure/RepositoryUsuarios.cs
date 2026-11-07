using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryUsuarios : IRepository<Usuario, int>, IUnitOfWork
    {
        #region Singleton
        private static RepositoryUsuarios? _instance;
        public static RepositoryUsuarios GetInstance(IDataStore<Usuario> store)
        {
            if (_instance == null)
            {
                _instance = new RepositoryUsuarios(store);
            }
            return _instance;
        }
        #endregion

        private Repository<Usuario, int> _repository;

        private RepositoryUsuarios(IDataStore<Usuario> store)
        {
            _repository = new Repository<Usuario, int>(store);
        }

        // Hash SHA-256 en mayusculas: igual al UPPER(SHA2(clave, 256)) de los datos de prueba
        public static string HashPassword(string clave)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(clave));
            return Convert.ToHexString(bytes);
        }

        // Add guarda entity.Password tal cual: debe llegar ya con el hash (preferir Registrar)
        public void Add(Usuario u)
        {
            Validar(u);
            _repository.Add(u);
        }

        public void Update(Usuario u)
        {
            Validar(u);
            _repository.Update(u);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _repository.GetAll();
        }

        public Usuario? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Commit()
        {
            _repository.Commit();
        }

        // Extra (no esta en IRepository): crea el usuario de un empleado con la clave ya cifrada.
        // Recibe un Empleado para que solo el personal del conjunto pueda tener usuario.
        public Usuario Registrar(Empleado empleado, string nombreUsuario, string clave, RolUsuario rol)
        {
            Usuario usuario = Usuario.Create();
            usuario.PersonaDocumento = empleado.Id;
            usuario.NombreUsuario = nombreUsuario;
            usuario.Password = HashPassword(clave);
            usuario.Rol = rol;

            Add(usuario);
            return usuario;
        }

        // Extra: cambia la clave de un usuario guardándola cifrada
        public void CambiarClave(Usuario usuario, string nuevaClave)
        {
            usuario.Password = HashPassword(nuevaClave);
            Update(usuario);
        }

        // Extra: busca por nombre de usuario sin distinguir mayúsculas (igual que la base)
        public Usuario? GetByNombreUsuario(string nombreUsuario)
        {
            return _repository.GetAll().FirstOrDefault(u =>
                string.Equals(u.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        // Extra: usuario asignado a una persona (o null si no tiene)
        public Usuario? GetByPersona(string documento)
        {
            return _repository.GetAll().FirstOrDefault(u => u.PersonaDocumento == documento);
        }

        // Login: devuelve el usuario si el nombre y la clave coinciden, o null si no
        public Usuario? Autenticar(string nombreUsuario, string clave)
        {
            Usuario? usuario = GetByNombreUsuario(nombreUsuario);

            if (usuario != null && usuario.Password == HashPassword(clave))
            {
                return usuario;
            }
            return null;
        }

        // Reglas de la tabla: nombre de usuario único y una persona con máximo un usuario.
        // Se revisan antes de guardar para dar un mensaje claro en vez de un error de la base.
        private void Validar(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.PersonaDocumento))
            {
                throw new InvalidOperationException("El usuario debe estar asignado a una persona.");
            }

            if (EsOtro(GetByNombreUsuario(u.NombreUsuario), u))
            {
                throw new InvalidOperationException($"Ya existe el usuario '{u.NombreUsuario}'.");
            }

            if (EsOtro(GetByPersona(u.PersonaDocumento), u))
            {
                throw new InvalidOperationException($"La persona {u.PersonaDocumento} ya tiene un usuario.");
            }
        }

        // true si "encontrado" es un usuario distinto a "u" (los nuevos tienen Id 0, por eso se compara también la referencia)
        private static bool EsOtro(Usuario? encontrado, Usuario u)
        {
            if (encontrado == null || ReferenceEquals(encontrado, u))
            {
                return false;
            }
            return u.Id == 0 || encontrado.Id != u.Id;
        }
    }
}

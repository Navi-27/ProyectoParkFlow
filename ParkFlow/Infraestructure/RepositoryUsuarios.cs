using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using ParkFlow.Tools;
using System;
using System.Collections.Generic;
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

        public Usuario Registrar(Empleado empleado, string nombreUsuario, string clave, RolUsuario rol)
        {
            Usuario usuario = Usuario.Create();
            usuario.PersonaDocumento = empleado.Id;
            usuario.NombreUsuario = nombreUsuario;
            usuario.Password = Seguridad.HashPassword(clave);
            usuario.Rol = rol;

            Add(usuario);
            return usuario;
        }

        public void CambiarClave(Usuario usuario, string nuevaClave)
        {
            usuario.Password = Seguridad.HashPassword(nuevaClave);
            Update(usuario);
        }

        public Usuario? GetByNombreUsuario(string nombreUsuario)
        {
            return _repository.GetAll().FirstOrDefault(u =>
                string.Equals(u.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario? GetByPersona(string documento)
        {
            return _repository.GetAll().FirstOrDefault(u => u.PersonaDocumento == documento);
        }

        public Usuario? Autenticar(string nombreUsuario, string clave)
        {
            Usuario? usuario = GetByNombreUsuario(nombreUsuario);

            if (usuario != null && usuario.Password == Seguridad.HashPassword(clave))
            {
                return usuario;
            }
            return null;
        }

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

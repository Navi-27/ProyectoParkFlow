using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Infraestructure
{
    internal class Repository<T, E> : IRepository<T, E>, IUnitOfWork where T : class, IEntity<E>
    {
        private List<T> _cache;
        private IDataStore<T> _store;

        public Repository(IDataStore<T> store)
        {
            _store = store;
            _cache = _store.LoadAll().ToList();
        }

        public void Add(T entity)
        {
            bool esNuevo = EqualityComparer<E>.Default.Equals(entity.Id, default!);

            // Evita duplicados: si el id ya existe, al hacer Commit se sobrescribirian los datos del registro original
            if (!esNuevo && Exist(entity.Id))
            {
                throw new InvalidOperationException($"Ya existe un registro con el id {entity.Id}.");
            }
            _cache.Add(entity);
        }

        public void Update(T entity)
        {
            int index = _cache.FindIndex(d => Equals(d.Id, entity.Id));
            if (index != -1)
            {
                _cache[index] = entity;
            }
        }

        public void Delete(E id)
        {
            T? item = GetById(id);
            if (item != null)
            {
                _cache.Remove(item);
            }
        }

        public bool Exist(E id)
        {
            return _cache.Exists(c => Equals(c.Id, id));
        }

        public IEnumerable<T> GetAll()
        {
            return _cache;
        }

        public T? GetById(E id)
        {
            return _cache.FirstOrDefault(c => Equals(c.Id, id));
        }

        public void Commit()
        {
            try
            {
                _store.SaveAll(_cache);
            }
            catch
            {
                _cache = _store.LoadAll().ToList();
                throw;
            }
            
        }
    }
}

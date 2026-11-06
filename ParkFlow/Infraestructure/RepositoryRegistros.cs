using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryRegistros : IRepository<Registro, int>,IUnitOfWork
    {
        #region Singletoon
        private static RepositoryRegistros? _instancie;
        private static RepositoryRegistros GetInstancie(IDataStore<Registro> store)
        {
            if(_instancie == null)
            {
                _instancie = new RepositoryRegistros(store);
            }
            return _instancie;
        }
        #endregion

        private Repository<Registro,int> _repository;
        private RepositoryRegistros(IDataStore<Registro> store)
        {
            _repository = new Repository<Registro, int>(store);
        }

        public void Add(Registro r)
        {
            _repository.Add(r);
        }

        public void Update(Registro r)
        {
          _repository.Update(r);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public bool Exist(int id)
        {
           return _repository.Exist(id);
        }

        public Registro? GetById(int id)
        {
           return _repository.GetById(id);
        }

        public IEnumerable<Registro> GetAll()
        {
           return _repository.GetAll();
        }

        // Extra (no esta en IRepository): visitas que aun no han salido
        public IEnumerable<Registro> GetActivas()
        {
            return _repository.GetAll().Where(e => e.FechaSalida == null).ToList();
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }
}

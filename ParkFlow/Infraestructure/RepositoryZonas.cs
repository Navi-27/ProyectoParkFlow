using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryZonas : IRepository<Zona, int>, IUnitOfWork
    {
        #region Singletoon
        private static RepositoryZonas? _instancie;
        private static RepositoryZonas GetInstacie(IDataStore<Zona> store)
        {
            if (_instancie == null)
            { 
                _instancie = new RepositoryZonas(store);
            }
            return _instancie;
        }
        #endregion

        private Repository<Zona, int> _repository;
        private RepositoryZonas(IDataStore<Zona> store)
        {
            _repository = new Repository<Zona, int>(store);
        }

        public void Add(Zona z)
        {
            _repository.Add(z);
        }

        public void Update(Zona z)
        {
            _repository.Update(z);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public bool Exist(int id)
        {
           return _repository.Exist(id);
        }

        public IEnumerable<Zona> GetAll()
        {
            return _repository.GetAll();
        }

        public Zona? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Commit()
        {
            _repository.Commit();
        }

        
    }
}

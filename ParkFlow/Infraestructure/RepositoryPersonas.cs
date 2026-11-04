using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryPersonas : IRepository<Persona, string>, IUnitOfWork
    {
        #region Singleton
        private static RepositoryPersonas? _instance;
        private static RepositoryPersonas GetInstance(IDataStore<Persona> store)
        {
            if (_instance == null)
            {
                _instance = new RepositoryPersonas(store);
            }
            return _instance;
        }
        #endregion

        private Repository<Persona, string> _repository;

        private RepositoryPersonas(IDataStore<Persona> store)
        {
            _repository = new Repository<Persona, string>(store);
        }

        public void Add(Persona p)
        {
            _repository.Add(p);
        }

        public void Update(Persona p)
        {
            _repository.Update(p);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public bool Exist(string id)
        {
            return _repository.Exist(id);
        }

        public IEnumerable<Persona> GetAll()
        {
            return _repository.GetAll();
        }

        public Persona? GetById(string id)
        {
            return _repository.GetById(id);
        }

        public void Commit()
        {
            _repository.Commit();
        }


    }
}
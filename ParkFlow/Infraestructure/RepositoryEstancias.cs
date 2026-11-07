using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryEstancias : IRepository<Estancia, int> ,IUnitOfWork
    {
        #region Singleton
        private static RepositoryEstancias? _instance;
        public static RepositoryEstancias GetInstance(IDataStore<Estancia> store)
        {
            if (_instance == null)
            {
                _instance = new RepositoryEstancias(store);
            }
            return _instance;
        }
        #endregion

        private Repository<Estancia, int> _repository;

        private RepositoryEstancias(IDataStore<Estancia> store)
        {
            _repository = new Repository<Estancia, int>(store);
        }

        public void Add(Estancia e)
        {
            _repository.Add(e);
        }

        public void Update(Estancia e)
        {
            _repository.Update(e);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public Estancia? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Estancia> GetAll()
        {
            return _repository.GetAll();
        }

        public void Commit()
        {
            _repository.Commit();
        }

        // Extra (no esta en IRepository): estancias que aun no han salido
        public IEnumerable<Estancia> GetActivas()
        {
            return _repository.GetAll().Where(e => e.FechaSalida == null).ToList();
        }
    }
}

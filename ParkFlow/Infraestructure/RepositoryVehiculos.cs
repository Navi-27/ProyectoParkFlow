using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryVehiculos : IRepository<Vehiculo, string> ,IUnitOfWork
    {
        #region Singleton
        private static RepositoryVehiculos? _instance;
        public static RepositoryVehiculos GetInstance(IDataStore<Vehiculo> store)
        {
            if(_instance == null)
            {
                _instance = new RepositoryVehiculos(store);
            }
            return _instance;
        }
        #endregion

        private Repository<Vehiculo, string> _repository;
        private RepositoryVehiculos(IDataStore<Vehiculo> store)
        {
            _repository = new Repository<Vehiculo, string>(store);
        }

        public void Add(Vehiculo vehiculo)
        {
            _repository.Add(vehiculo);
        }

        public void Update(Vehiculo v)
        {
           _repository.Update(v);
        }

        public void Delete(string id)
        {
           _repository.Delete(id);
        }

        public bool Exist(string id)
        {
           return _repository.Exist(id);
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            return _repository.GetAll();
        }

        public Vehiculo? GetById(string id)
        {
           return _repository.GetById(id);
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }

}

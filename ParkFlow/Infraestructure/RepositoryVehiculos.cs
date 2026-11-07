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
        #region Singletoon
        private static RepositoryVehiculos? _instancie;
        private static RepositoryVehiculos? GetInstancie(IDataStore<Vehiculo> store)
        {
            if(_instancie == null)
            {
                _instancie = new RepositoryVehiculos(store);
            }
            return _instancie;
        }
        #endregion

        private Repository<Vehiculo, string> _repository;
        private RepositoryVehiculos(IDataStore<Vehiculo> store)
        {
            _repository = new Repository<Vehiculo, string>(store);
        }

        public void Add(Vehiculo envtity)
        {
            _repository.Add(v);
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

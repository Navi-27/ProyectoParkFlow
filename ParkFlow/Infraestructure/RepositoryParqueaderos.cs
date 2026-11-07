using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryParqueaderos : IRepository<Parqueadero, int>, IUnitOfWork
    {
        private static RepositoryParqueaderos? _instance;
        public static RepositoryParqueaderos GetInstance(IDataStore<Parqueadero> store)
        {
            if (_instance == null)
            {
                return _instance = new RepositoryParqueaderos(store);
            }
            return _instance;
        }

        private Repository<Parqueadero, int> _repository;

        private RepositoryParqueaderos(IDataStore<Parqueadero> store)
        {
            _repository = new Repository<Parqueadero, int>(store);
        }

        public void Add(Parqueadero p)
        {
            _repository.Add(p);
        }

        public void Update(Parqueadero p)
        {
            _repository.Update(p);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public IEnumerable<Parqueadero> GetAll()
        {
            return _repository.GetAll();
        }

        public Parqueadero? GetById(int id)
        {
            return _repository.GetById(id);
        }

        //Plazas sin vehiculo(vehiculo_placa NULL = libre)
        public IEnumerable<Parqueadero> GetLibres()
        {
            return _repository.GetAll().Where(p => p.Libre).ToList();
        }
        
        public void Commit()
        {
            _repository.Commit();
        }
    }
}
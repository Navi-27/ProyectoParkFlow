using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.models;
using ParkFlow.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryViviendas : IRepository<Vivienda, int>,IUnitOfWork
    {
        #region Singleton
        private static RepositoryViviendas? _instance;
        public static RepositoryViviendas GetInstance(IDataStore<Vivienda> store)
        {
            if(_instance == null)
            {
                _instance = new RepositoryViviendas(store);
            }
            return _instance;
        }
        #endregion

        private Repository<Vivienda, int> _repository;
        private RepositoryViviendas(IDataStore<Vivienda> store)
        {
            _repository = new Repository<Vivienda, int>(store);
        }

        public void Add(Vivienda v)
        {
            _repository.Add(v);
        }

        public void Update(Vivienda v)
        {
            _repository.Update(v);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public IEnumerable<Vivienda> GetAll()
        {
            return _repository.GetAll();
        }

        public Vivienda? GetById(int id)
        {
           return _repository.GetById(id);
        }

        // Ejecuta un SELECT y devuelve todas las viviendas que encuentre
        private List<Vivienda> Consultar(string documento)
        {
            return _repository.GetAll().Where(v => v.PersonaDocumento == documento).ToList();
        }

        // Extra (no esta en IRepository): viviendas de un residente.
        // Sirve para elegir la vivienda al registrar una visita.
        public IEnumerable<Vivienda> GetByPersona(string documento)
        {
            return _repository.GetAll().Where(v => v.PersonaDocumento == documento).ToList();
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }
}

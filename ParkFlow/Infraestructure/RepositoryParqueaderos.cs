using MySqlConnector;
using ParkFlow.Contracts;
using ParkFlow.DynamicStructure;
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

        public IEnumerable<Parqueadero> GetLibres()
        {
            return _repository.GetAll().Where(p => p.Libre).ToList();
        }

        public Parqueadero? BuscarPlazaLibre(Persona? dueno)
        {
            if (dueno == null) return null;

            Lista<Parqueadero> libres = new Lista<Parqueadero>(GetLibres());

            Parqueadero? fija = libres.FirstOrDefault(p => p.PersonaDocumento == dueno.Id);
            if (fija != null) return fija;

            if (dueno.MovilidadReducida)
            {
                Parqueadero? movilidad = libres.FirstOrDefault(p => p.Tipo == "MOVILIDAD_REDUCIDA" && p.PersonaDocumento == "");
                if (movilidad != null) return movilidad;
            }

            if (dueno is Residente)
            {
                return libres.FirstOrDefault(p => p.Tipo == "RESIDENTE" && p.PersonaDocumento == "");
            }

            return libres.FirstOrDefault(p => p.Tipo == "VISITANTE");
        }
        
        public void Commit()
        {
            _repository.Commit();
        }
    }
}
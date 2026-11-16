using ParkFlow.Contracts;
using ParkFlow.models;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryNodos : IRepository<NodoRuta, int>, IUnitOfWork
    {
        #region Singleton
        private static RepositoryNodos? _instance;
        public static RepositoryNodos GetInstance(IDataStore<NodoRuta> store)
        {
            if (_instance == null)
            {
                _instance = new RepositoryNodos(store);
            }
            return _instance;
        }
        #endregion

        private Repository<NodoRuta, int> _repository;
        private RepositoryNodos(IDataStore<NodoRuta> store)
        {
            _repository = new Repository<NodoRuta, int>(store);
        }

        public void Add(NodoRuta n)
        {
            _repository.Add(n);
        }

        public void Update(NodoRuta n)
        {
            _repository.Update(n);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public IEnumerable<NodoRuta> GetAll()
        {
            return _repository.GetAll();
        }

        public NodoRuta? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }
}

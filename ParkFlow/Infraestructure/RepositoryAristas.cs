using ParkFlow.Contracts;
using ParkFlow.models;

namespace ParkFlow.Infraestructure
{
    internal class RepositoryAristas : IRepository<AristaRuta, int>, IUnitOfWork
    {
        #region Singleton
        private static RepositoryAristas? _instance;
        public static RepositoryAristas GetInstance(IDataStore<AristaRuta> store)
        {
            if (_instance == null)
            {
                _instance = new RepositoryAristas(store);
            }
            return _instance;
        }
        #endregion

        private Repository<AristaRuta, int> _repository;
        private RepositoryAristas(IDataStore<AristaRuta> store)
        {
            _repository = new Repository<AristaRuta, int>(store);
        }

        public void Add(AristaRuta a)
        {
            _repository.Add(a);
        }

        public void Update(AristaRuta a)
        {
            _repository.Update(a);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public IEnumerable<AristaRuta> GetAll()
        {
            return _repository.GetAll();
        }

        public AristaRuta? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }
}

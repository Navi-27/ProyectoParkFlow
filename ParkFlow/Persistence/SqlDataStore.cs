using MySqlConnector;
using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
//using System.Security.Cryptography; no se sabe porque anda aqui, no se usa
using System.Text;

namespace ParkFlow.Persistence
{
    internal  abstract class SqlDataStore<T, E> : IDataStore<T> where T : class, IEntity<E>
    {
        protected abstract string SelectSql { get; }
        protected abstract string UpsertSql { get; }   
        protected abstract string DeleteSql { get; }  
        protected abstract T Map(MySqlDataReader reader);
        protected abstract void SetParameters(MySqlCommand cmd, T entity);

        public IEnumerable<T> LoadAll()
        {
            List<T> list = new List<T>();
            using MySqlConnection con = Database.CreateConnection();
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(SelectSql, con))
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }
            return list;
        }

        public void SaveAll(IEnumerable<T> list)
        {
            List<T> nuevosElementos = list.ToList();
            List<T> elementosBase = LoadAll().ToList();

            using MySqlConnection con = Database.CreateConnection();
            {
                con.Open();
                using (MySqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        foreach(T itemViejo in elementosBase)
                        {
                            if (!nuevosElementos.Exists(n => Equals(n.Id, itemViejo.Id)))
                            {
                                using (MySqlCommand cmd = new MySqlCommand(DeleteSql, con, tran))
                                {
                                    cmd.Parameters.AddWithValue("@id", itemViejo.Id);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        foreach (T itemNuevo in nuevosElementos)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(UpsertSql, con, tran))
                            {
                                SetParameters(cmd, itemNuevo);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }

        }
    }
}

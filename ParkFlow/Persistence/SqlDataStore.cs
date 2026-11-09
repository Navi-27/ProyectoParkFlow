using MySqlConnector;
using ParkFlow.Contracts;
using System;
using System.Collections.Generic;
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
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Map(reader));
                    }
                }
            }
            return list;
        }

        public void SaveAll(IEnumerable<T> list, IEnumerable<T> removed)
        {
            using (MySqlConnection con = Database.CreateConnection())
            {
                con.Open();
                using (MySqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        foreach (T item in removed)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(DeleteSql, con, tran))
                            {
                                cmd.Parameters.AddWithValue("@id", item.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        foreach (T item in list)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(UpsertSql, con, tran))
                            {
                                SetParameters(cmd, item);
                                cmd.ExecuteNonQuery();

                                if (item.Id is int id && id == 0)
                                {
                                    item.Id = (E)(object)Convert.ToInt32(cmd.LastInsertedId);
                                }
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}

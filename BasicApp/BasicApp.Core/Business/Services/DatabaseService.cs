using System;
using SQLite.Net;
using System.Linq;
using System.Collections.Generic;
using BasicApp.Business.Factories;
using BasicApp.Core.Business.Models;

namespace BasicApp.Business.Services
{
    public interface IDatabaseService
    {
        void Insert<T>(T obj);
        void InsertCollection<T>(List<T> objs);

        void Delete<T>(int id) where T : class;
        void DeleteCollection<T>(Func<T, bool> predicate = null) where T : class;

        void Update<T>(T obj);

        T Get<T>(int? id) where T : class;
        List<T> GetCollection<T>(Func<T, bool> predicate = null) where T : class;

        T Find<T>(int id) where T : class;

    }

    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteConnection _databaseConnection;
        private readonly object _locker = new object();

        public DatabaseService(ISQLiteConnection database)
        {
            _databaseConnection = database.CreateConnection();

            _databaseConnection.ExecuteScalar<int>("PRAGMA journal_mode=WAL");
            _databaseConnection.Execute("PRAGMA temp_store=MEMORY");
            _databaseConnection.Execute("PRAGMA synchronous=OFF");

            CreateTables();
        }

        void CreateTables()
        {
            _databaseConnection.CreateTable<Training>();
        }

        public void Insert<T>(T obj)
        {
            lock (_locker)
            {
                _databaseConnection.Insert(obj);
            }
        }

        public void InsertCollection<T>(List<T> objs)
        {
            lock (_locker)
            {
                _databaseConnection.InsertAll(objs);
            }
        }

        public void Delete<T>(int id) where T : class
        {
            lock (_locker)
            {
                T item = Get<T>(id);

                _databaseConnection.Delete(item);
            }
        }

        public void Update<T>(T obj)
        {
            lock (_locker)
            {
                _databaseConnection.Update(obj);
            }
        }

        public T Get<T>(int? id) where T : class
        {
            lock (_locker)
            {
                if (id.HasValue)
                {
                    try
                    {
                        return _databaseConnection.Get<T>(id);
                    }
                    catch
                    {
                        return null;
                    }
                }
                return _databaseConnection.Table<T>().FirstOrDefault();
            }
        }

        public T Find<T>(int id) where T : class
        {
            lock (_locker)
            {
                return _databaseConnection.Find<T>(id);
            }
        }

        public List<T> GetCollection<T>(Func<T, bool> predicate = null) where T : class
        {
            lock (_locker)
            {
                if (predicate == null)
                    predicate = x => true;
                return _databaseConnection.Table<T>().Where(predicate).ToList();
            }
        }

        public void DeleteCollection<T>(Func<T, bool> predicate = null) where T : class
        {
            lock (_locker)
            {
                if (predicate == null)
                {
                    _databaseConnection.DeleteAll<T>();
                    return;
                }

                var collection = GetCollection(predicate);
                foreach (var item in collection)
                {
                    _databaseConnection.Delete(item);
                }
            }
        }
    }
}

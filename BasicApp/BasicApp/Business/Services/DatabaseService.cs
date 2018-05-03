using System;
using System.Collections.Generic;
using System.Linq;
using BasicApp.Business.Factories;
using BasicApp.Business.Models;
using SQLite.Net;

namespace BasicApp.Business.Services
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Insert the specified obj.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="obj">Object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void Insert<T>(T obj);

        /// <summary>
        /// Inserts the collection.
        /// </summary>
        /// <param name="objs">Objects.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void InsertCollection<T>(List<T> objs);

        /// <summary>
        /// Delete the specified obj with id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void Delete<T>(int id) where T : class;

        /// <summary>
        /// Update the specified obj.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="obj">Object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void Update<T>(T obj);

        /// <summary>
        /// Get the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        T Get<T>(int? id) where T : class;

        T Find<T>(int id) where T : DataObject;

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <returns>The collection.</returns>
        /// <param name="predicate">Predicate.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        List<T> GetCollection<T>(Func<T, bool> predicate = null) where T : class;

        /// <summary>
        /// Deletes the collection.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void DeleteCollection<T>(Func<T, bool> predicate = null) where T : class;
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
            _databaseConnection.CreateTable<MenuItem>();
        }

        /// <summary>
        /// Insert the specified obj.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="obj">Object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void Insert<T>(T obj)
        {
            lock (_locker)
            {
                _databaseConnection.Insert(obj);
            }
        }

        /// <summary>
        /// Inserts the collection.
        /// </summary>
        /// <param name="objs">Objects.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void InsertCollection<T>(List<T> objs)
        {
            lock (_locker)
            {
                _databaseConnection.InsertAll(objs);
            }
        }

        /// <summary>
        /// Delete object with specified id.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void Delete<T>(int id) where T : class
        {
            lock (_locker)
            {
                T item = Get<T>(id);

                _databaseConnection.Delete(item);
            }
        }

        /// <summary>
        /// Update the specified obj.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="obj">Object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public void Update<T>(T obj)
        {
            lock (_locker)
            {
                _databaseConnection.Update(obj);
            }
        }

        /// <summary>
        /// Get the specified object with id or returns the first item from the table if there is any.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
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

        /// <summary>
        /// Get the specified object with id or returns null if it is not found.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T Find<T>(int id) where T : DataObject
        {
            lock (_locker)
            {
                return _databaseConnection.Find<T>(id);
            }
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <returns>The collection.</returns>
        /// <param name="predicate">Predicate.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public List<T> GetCollection<T>(Func<T, bool> predicate = null) where T : class
        {
            lock (_locker)
            {
                if (predicate == null)
                    predicate = x => true;
                return _databaseConnection.Table<T>().Where(predicate).ToList();
            }
        }

        /// <summary>
        /// Deletes the collection.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
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

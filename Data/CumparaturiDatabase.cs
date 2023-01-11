using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AplicatieMobila.Models;
namespace AplicatieMobila.Data
{
    public class CumparaturiDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CumparaturiDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Comenzi>().Wait();
        }
        public Task<List<Comenzi>> GetComenzisAsync()
        {
            return _database.Table<Comenzi>().ToListAsync();
        }
        public Task<Comenzi> GetComenziAsync(int id)
        {
            return _database.Table<Comenzi>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveComenziAsync(Comenzi slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteComenziAsync(Comenzi slist)
        {
            return _database.DeleteAsync(slist);
        }
    }

}

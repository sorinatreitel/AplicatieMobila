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
            _database.CreateTableAsync<Echipament>().Wait();
            _database.CreateTableAsync<ListEchipament>().Wait();
            _database.CreateTableAsync<Magazin>().Wait();
        }
        public Task<int> SaveListEchipamentAsync(ListEchipament listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Echipament>> GetListEchipamenteAsync(int shoplistid)
        {
            return _database.QueryAsync<Echipament>(
            "select P.ID, P.Description from Echipament P"
            + " inner join ListEchipament LP"
            + " on P.ID = LP.EchipamentID where LP.ComenziID = ?",
            shoplistid);
        }
        public Task<int> SaveEchipamentAsync(Echipament echipament)
        {
            if (echipament.ID != 0)
            {
                return _database.UpdateAsync(echipament);
            }
            else
            {
                return _database.InsertAsync(echipament);
            }
        }
        public Task<int> DeleteEchipamentAsync(Echipament echipament)
        {
            return _database.DeleteAsync(echipament);
        }
        public Task<List<Echipament>> GetEchipamenteAsync()
        {
            return _database.Table<Echipament>().ToListAsync();
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
        public Task<int> DeleteListEchipamentAsync(ListEchipament listp)
        {
            return _database.DeleteAsync(listp);
        }
        public Task<int> DeleteComenziAsync(Comenzi slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<List<ListEchipament>> GetListEchipamente()
        {
            return _database.QueryAsync<ListEchipament>("select * from ListEchipament");
        }
        public Task<List<Magazin>> GetMagazineAsync()
        {
            return _database.Table<Magazin>().ToListAsync();
        }
        public Task<int> SaveMagazinAsync(Magazin shop)
        {
            if (shop.ID != 0)
            {
                return _database.UpdateAsync(shop);
            }
            else
            {
                return _database.InsertAsync(shop);
            }

        }
        public Task<int> DeleteMagazinAsync(Magazin shop)
        {
            return _database.DeleteAsync(shop);
        }

    }
}
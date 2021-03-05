using HIITAppFinal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HIITAppFinal.Services
{
    public class SQLiteDataStore : IDataStore<Item>
    {
        readonly SQLiteAsyncConnection database;
        public SQLiteDataStore()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3");
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Item>().Wait();
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                int addedItem = await database.InsertAsync(item);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                await database.DeleteAsync(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Task<Item> GetItemAsync(string id)
        {
            return database.Table<Item>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return database.Table<Item>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            try
            {
                int updatedItem = await database.UpdateAsync(item);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using RecipeApp.Models;

namespace RecipeApp.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RecipeDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        public Task<List<Recipe>> GetRecipeAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        public Task<Recipe> GetRecipeAsync(int id)
        {
            return _database.Table<Recipe>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            if (recipe.ID != 0)
            {
                return _database.UpdateAsync(recipe);
            }
            else
            {
                return _database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }
    }
}

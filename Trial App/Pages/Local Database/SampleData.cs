using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial_App.Pages.Local_Database.Models;

namespace Trial_App.Pages.Local_Database
{
    public class SampleData
    {
        readonly SQLiteAsyncConnection database;

        public SampleData(string dPath)
        {
            database = new SQLiteAsyncConnection(dPath);
            database.CreateTableAsync<todoList>().Wait();
        }


        public async Task<List<todoList>> GetList()
        {
            var todoItem = await database.Table<todoList>().ToListAsync();

            if (!todoItem.Any())
            {
                await database.InsertAllAsync(new todoList[] 
                {
                    new todoList{ID = 1, listItems = "First Database" , timeStamp = DateTime.UtcNow.ToString("F")},
                    new todoList{ID = 2, listItems = "Second Database" , timeStamp = DateTime.UtcNow.ToString("F")},
                    new todoList{ID = 3, listItems = "Third Database" , timeStamp = DateTime.UtcNow.ToString("F")},
                    new todoList{ID = 4, listItems = "Fourth Database" , timeStamp = DateTime.UtcNow.ToString("F")},
                    new todoList{ID = 5, listItems = "Fifth Database" , timeStamp = DateTime.UtcNow.ToString("F")},
                });
                return await database.Table<todoList>().ToListAsync();
            }
            return todoItem;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace Barkot
{
    public class Repository
    {
        SQLiteConnection database;
        public Repository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Card>();
        }
        //Получение всех Элементов
        public IEnumerable<Card> GetItems()
        {
            return (from i in database.Table<Card>() select i).ToList();

        }
        //Получение элемента по id
        public Card GetItem(int id)
        {
            return database.Get<Card>(id);
        }
        //Удаление элемента
        public int DeleteItem(int id)
        {
            return database.Delete<Card>(id);
        }
        //Сохранение элемента
        public int SaveItem(Card item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
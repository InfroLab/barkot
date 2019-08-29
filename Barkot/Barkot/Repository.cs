using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Barkot
{
    public class Repository
    {
        SQLiteConnection database;
        public Repository(string filename)
        {
            //???
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<CardViewModel>();
        }
        //Получение всех Элементов
        public IEnumerable<CardViewModel> GetItems()
        {
            return (from i in database.Table<CardViewModel>() select i).ToList();
        }
        //Получение элемента по id
        public CardViewModel GetItem(int id)
        {
            return database.Get<CardViewModel>(id);
        }
        //Удаление элемента
        public int DeleteItem(int id)
        {
            return database.Delete<CardViewModel>(id);
        }
        //Сохранение элемента
        public int SaveItem(CardViewModel item)
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
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;

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
            database.CreateTable<Card>();
        }
        //Получение всех Элементов
        public ObservableCollection<CardViewModel> GetItems()
        {
            var table = database.Table<Card>();
            ObservableCollection<CardViewModel> records = new ObservableCollection<CardViewModel>();
            foreach(var record in table)
            {
                records.Add(new CardViewModel(record.Id, record.Company, record.Barcode, record.Type, record.Site));
            }
            return records;
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
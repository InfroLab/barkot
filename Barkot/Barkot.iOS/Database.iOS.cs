using System;
using Xamarin.Forms;
using System.IO;
using Barkot.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace Barkot.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        //Реализация интерфейса ISQLite из класса Database
        public string GetDatabasePath(string sqliteFilename)
        {
            // Определяем путь к бд ??
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // ??
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            // ??
            var path = Path.Combine(libraryPath, sqliteFilename);

            return path;
        }
    }
}
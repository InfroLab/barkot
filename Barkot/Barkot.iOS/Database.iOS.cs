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
        public string GetDatabasePath(string sqliteFilename)
        {
            // определяем путь к бд
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, sqliteFilename);

            if (!File.Exists(path))
            {
                File.Copy(sqliteFilename, path);
            }

            return path;
        }
    }
}
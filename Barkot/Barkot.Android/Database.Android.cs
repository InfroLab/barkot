using System;
using Xamarin.Forms;
using System.IO;
using Barkot.Android;


[assembly: Dependency(typeof(SQLite_Android))]
namespace Barkot.Android
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}
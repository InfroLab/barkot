namespace Barkot
{
    //Интерфейс метода получения пути БД
    //Необходим, т.к. на разных платформах полный путь разный
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
    class Database
    {
    }
}

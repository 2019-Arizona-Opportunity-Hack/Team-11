using System;
using System.IO;
using SQLite;
using TeacherLeague.Droid.SQLiteImplementation;
using TeacherLeague.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace TeacherLeague.Droid.SQLiteImplementation
{
    public class AndroidSQLite : ISQLiteHelper
    {
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, AppConstants.TeacherLeagueDb);
            return new SQLiteAsyncConnection(path);
        }
    }
}

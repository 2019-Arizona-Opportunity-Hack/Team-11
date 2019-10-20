using System;
using System.Diagnostics;
using System.IO;
using SQLite;
using TeacherLeague.Helpers;
using TeacherLeague.iOS.SQLiteImplementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosSQLite))]
namespace TeacherLeague.iOS.SQLiteImplementations
{
    public class IosSQLite : ISQLiteHelper
    {
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var lib = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(lib, AppConstants.TeacherLeagueDb);
            Debug.WriteLine(path);
            return new SQLiteAsyncConnection(path);
        }
    }
}

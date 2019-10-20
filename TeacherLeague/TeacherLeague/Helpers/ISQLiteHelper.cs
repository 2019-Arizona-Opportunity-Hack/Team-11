using System;
using SQLite;

namespace TeacherLeague.Helpers
{
    public interface ISQLiteHelper
    {
        SQLiteAsyncConnection GetConnectionAsync();
    }
}

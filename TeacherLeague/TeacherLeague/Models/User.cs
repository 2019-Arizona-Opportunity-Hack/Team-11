using System;
using SQLite;

namespace TeacherLeague.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Subject { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }
    }
}

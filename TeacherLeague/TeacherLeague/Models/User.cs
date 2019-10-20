using System;
using Newtonsoft.Json;
using SQLite;

namespace TeacherLeague.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Bio")]
        public string Bio { get; set; }
        [JsonProperty("Subject")]
        public string Subject { get; set; }
        [JsonProperty("School")]
        public string School { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
    }
}

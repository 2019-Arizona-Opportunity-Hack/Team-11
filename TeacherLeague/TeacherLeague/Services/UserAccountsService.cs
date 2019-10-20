using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeacherLeague.Models;

namespace TeacherLeague.Services
{
    public class UserAccountsService : IUserAccountsService
    {

        public UserAccountsService()
        {

        }

        public Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string name)
        {
            var httpClient = new HttpClient();
            UriBuilder builder = new UriBuilder(AppConstants.UserAccountsApi);
            builder.Path = "/users/" + name;
            var uri = builder.Uri;
            var response = await httpClient.GetStringAsync(uri);
            //var user = JsonConvert.DeserializeObject(response);
            JObject obj = JObject.Parse(response);

            return parseJsonToUser(obj);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task InsertUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        private User parseJsonToUser(JObject jsonString)
        {
            string name = jsonString["Name:"].Value<string>();
            string subject = jsonString["Subject:"].Value<string>();
            string grade = jsonString["Grade:"].Value<string>();
            string school = jsonString["School:"].Value<string>();
            string email = jsonString["Email:"].Value<string>();
            string bio = jsonString["Bio:"].Value<string>();
            return new User { Name = name, Bio = bio, Email = email, Grade = grade, School = school, Subject = subject };
        }
    }
}

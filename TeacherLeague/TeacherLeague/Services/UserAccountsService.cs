using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AirtableApiClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeacherLeague.Models;

namespace TeacherLeague.Services
{
    public class UserAccountsService : IUserAccountsService
    {
        public Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string email)
        {
            var httpClient = new HttpClient();
            UriBuilder builder = new UriBuilder(AppConstants.UserAccountsApi);
            builder.Path = "/users/" + email;
            var uri = builder.Uri;
            var response = await httpClient.GetStringAsync(uri);
            JObject obj = JObject.Parse(response);

            //var user = JsonConvert.DeserializeObject(response);
            Debug.WriteLine(obj.ToString());
            return parseJsonToUser(obj);
        }

        public async Task InsertUserAsync(User user)
        {
            using (AirtableBase airtableBase = new AirtableBase(AppConstants.AppKey, AppConstants.BaseId))
            {
                // Create Attachments list
                var attachmentList = new List<AirtableAttachment>();
                attachmentList.Add(new AirtableAttachment { Url = AppConstants.UserAccountsApi + "/userinfo" });

                var fields = new Fields();
                fields.AddField("Name", user.Name);
                fields.AddField("Bio", user.Bio);
                fields.AddField("Subject", user.Subject);
                fields.AddField("School", user.School);
                fields.AddField("Grade", user.Grade);
                fields.AddField("Email", user.Email);

                Task<AirtableCreateUpdateReplaceRecordResponse> task = airtableBase.CreateRecord("Users", fields, true);
                var response = await task;

                if (!response.Success)
                {
                    string errorMessage = null;
                    if (response.AirtableApiError is AirtableApiException)
                    {
                        errorMessage = response.AirtableApiError.ErrorMessage;
                    }
                    else
                    {
                        errorMessage = "Unknown error";
                    }
                    // Report errorMessage
                }
                else
                {
                    var record = response.Record;
                    // Do something with your created record.
                }
            }

        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        private User parseJsonToUser(JObject n)
        {
            string name = n["Name"].Value<string>();
            string subject = n["Subject"].Value<string>();
            string grade = n["Grade"].Value<string>();
            string school = n["School"].Value<string>();
            string email = n["Email"].Value<string>();
            string bio = n["Bio"].Value<string>();

            return new User { Name = name, Bio = bio, Email = email, Grade = grade, School = school, Subject = subject };
        }
    }
}

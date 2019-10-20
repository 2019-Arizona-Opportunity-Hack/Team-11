using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using TeacherLeague.Models;
using TeacherLeague.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherLeague.PageModels
{
    public class BaseAccountDetailPageModel : FreshBasePageModel
    {
        public IUserService _userService;

        public User _user;

        public BaseAccountDetailPageModel(IUserService userService)
        {
            _userService = userService;
            _user = new User();
           Task.Run(FetchUser);
        }

        async Task FetchUser()
        {
            var email = Application.Current.Properties["Email"].ToString();
            _user = await _userService.GetUserByEmailAsync(email);
        }

        public string Name
        {
            get => _user.Name;
            set
            {
                _user.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string School
        {
            get => _user.School;
            set
            {
                _user.School = value;
                RaisePropertyChanged("School");
            }
        }

        public string Subject
        {
            get => _user.Subject;
            set
            {
                _user.Subject = value;
                RaisePropertyChanged("Subject");
            }
        }

        public string Bio
        {
            get => _user.Bio;
            set
            {
                _user.Bio = value;
                RaisePropertyChanged("Bio");
            }
        }

        public string Grade
        {
            get => _user.Grade;
            set
            {
                _user.Grade = value;
                RaisePropertyChanged("Grade");
            }
        }
    }
}

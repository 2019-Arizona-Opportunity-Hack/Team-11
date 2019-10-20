using System;
using FreshMvvm;
using TeacherLeague.Models;
using TeacherLeague.Services;

namespace TeacherLeague.PageModels
{
    public class BaseAccountDetailPageModel : FreshBasePageModel
    {
        public IUserService _userService;

        public User _user;

        public BaseAccountDetailPageModel(IUserService userService)
        {
            _userService = userService;
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

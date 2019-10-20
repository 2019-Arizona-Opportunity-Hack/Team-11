using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using TeacherLeague.Models;
using TeacherLeague.Services;
using Xamarin.Forms;

namespace TeacherLeague.PageModels
{
    public class SignUpPageModel : FreshBasePageModel
    {

        public ICommand FinishSignUpCommand { get; private set; }

        IUserService _userService;

        public SignUpPageModel(IUserService userService)
        {
            _userService = userService;
            
            FinishSignUpCommand = new Command(async () => await FinishSignUp());
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _grade;
        public string Grade
        {
            get => _grade;
            set
            {
                _grade = value;
                RaisePropertyChanged("Grade");
            }
        }

        private string _subjects;
        public string Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                RaisePropertyChanged("Subjects");
            }
        }

        private string _school;
        public string School
        {
            get => _school;
            set
            {
                _school = value;
                RaisePropertyChanged("School");
            }
        }

        private string _bio;
        public string Bio
        {
            get => _bio;
            set
            {
                _bio = value;
                RaisePropertyChanged("Bio");
            }
        }

        async Task FinishSignUp()
        {
            var newUser = new User { Bio = _bio,
                Email = Application.Current.Properties["Email"].ToString(),
                Grade = _grade, Name = _name, School = _school, Subject = _subjects};
            await _userService.InsertUserAsync(newUser);

            // Create new tabbed nav page
            var tabbedNav = new FreshTabbedNavigationContainer("secondNav");
            tabbedNav.BarBackgroundColor = Color.FromHex("#386739");
            tabbedNav.SelectedTabColor = Color.FromHex("#8AAF91");
            tabbedNav.UnselectedTabColor = Color.White;
            tabbedNav.BarTextColor = Color.White;
            tabbedNav.AddTab<HomePageModel>("Home", "Home_Icon");
            tabbedNav.AddTab<CompetitionsPageModel>("Competitions", null);
            tabbedNav.AddTab<AboutPageModel>("About", "About_Icon");
            tabbedNav.AddTab<AccountDetailsPageModel>("Account", "Account_Icon");
            await CoreMethods.PushNewNavigationServiceModal(tabbedNav);
        }
    }
}

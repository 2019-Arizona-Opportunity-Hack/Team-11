using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using TeacherLeague.Models;
using TeacherLeague.Services;
using Xamarin.Forms;

namespace TeacherLeague.PageModels
{
    public class SignInPageModel : FreshBasePageModel
    {

        // IOC Members
        IUserAccountsService _userAccountsService;
        IUserService _userService;

        public ICommand LoginCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        public SignInPageModel(IUserAccountsService accountService, IUserService service)
        {
            _userAccountsService = accountService;
            _userService = service;

            LoginCommand = new Command(async () => await Login());
            SignUpCommand = new Command(async () => await SignUp());
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        async Task Login()
        {
            // If not in local DB we go to cloud
            User user = await _userService.GetUserByEmailAsync(Email.ToLower());

            if (user == null)
            {
                try
                {
                    // Check cloud for user in case local did not get updated
                    user = await _userAccountsService.GetUserAsync(Email.ToLower());
                }
                catch (Exception ex)
                {
                    await CoreMethods.DisplayAlert("Incorrect Login", "Your Username or Password was incorrect.", "Okay");
                }
            }

            if (user != null)
            {
                Application.Current.Properties["Email"] = Email;
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

        async Task SignUp()
        {
            await CoreMethods.PushPageModel<SignUpPageModel>();
        }

    }
}

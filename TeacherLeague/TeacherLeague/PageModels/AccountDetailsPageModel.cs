using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using TeacherLeague.Models;
using TeacherLeague.Services;
using Xamarin.Forms;

namespace TeacherLeague.PageModels
{
    public class AccountDetailsPageModel : BaseAccountDetailPageModel
    {

        // Commands
        public ICommand EditAccountInfoCommand { get; private set; }

        public AccountDetailsPageModel(IUserService userService) : base(userService)
        {
            _user = new User();
            
            EditAccountInfoCommand = new Command(async () => await EditAccountInfo());
        }

        // Pass user throughout the app
        public override void Init(object initData)
        { 
            base.Init(initData);

            Task.Run(async () => await FetchUserData());
        }

        async Task FetchUserData()
        {
            var email = Application.Current.Properties["Email"].ToString();
            await _userService.InsertUserAsync(_user);
            _user = await _userService.GetUserByEmailAsync(email.ToLower());
            // TODO: if user is null, hit API
        }

        async Task EditAccountInfo()
        {
            await CoreMethods.PushPageModel<EditAccountInfoPageModel>(_user);
        }

    }
}

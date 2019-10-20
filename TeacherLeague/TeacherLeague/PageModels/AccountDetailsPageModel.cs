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

            Task.Run(FetchUserData);
            EditAccountInfoCommand = new Command(async () => await EditAccountInfo());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            
            base.ViewIsAppearing(sender, e);
        }

        // Pass user throughout the app
        public override void Init(object initData)
        { 
            base.Init(initData);

        }

        async Task FetchUserData()
        {
            var email = Application.Current.Properties["Email"].ToString();
            _user = await _userService.GetUserByEmailAsync(email.ToLower());
            // TODO: if user is null, hit API
        }

        async Task EditAccountInfo()
        {
            await CoreMethods.PushPageModel<EditAccountInfoPageModel>(_user);
        }

    }
}

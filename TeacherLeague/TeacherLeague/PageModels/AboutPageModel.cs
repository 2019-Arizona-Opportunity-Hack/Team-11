using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace TeacherLeague.PageModels
{
    public class AboutPageModel : FreshBasePageModel
    {
        // Commands
        public ICommand DonateCommand { get; private set; }
        public ICommand BecomeASponsorCommand { get; private set; }

        public AboutPageModel()
        {
            DonateCommand = new Command(async () => await Donate());
            BecomeASponsorCommand = new Command(async () => await BecomeASponsor());

            AboutText = "This is some random about information about the nonprofit organization";
        }

        private string _aboutText;
        public string AboutText
        {
            get => _aboutText;
            set
            {
                _aboutText = value;
                RaisePropertyChanged("AboutText");
            }
        }

        // Private methods
        async Task Donate()
        {
            // TODO: Change this to proper page
            await CoreMethods.PushPageModel<AccountDetailsPageModel>();
        }

        async Task BecomeASponsor()
        {
            // TODO: Change this to proper page navigation
            await CoreMethods.PushPageModel<AccountDetailsPageModel>();
        }

    }
}

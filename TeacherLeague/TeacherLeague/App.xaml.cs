using System;
using FreshMvvm;
using TeacherLeague.PageModels;
using TeacherLeague.Pages;
using TeacherLeague.Repositories;
using TeacherLeague.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherLeague
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IUserRepository, UserRepository>();
            FreshIOC.Container.Register<IUserService, UserService>();
            FreshIOC.Container.Register<IUserAccountsService, UserAccountsService>();

            
            var mainPage = FreshPageModelResolver.ResolvePageModel<SignInPageModel>();
            MainPage = new FreshNavigationContainer(mainPage);


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

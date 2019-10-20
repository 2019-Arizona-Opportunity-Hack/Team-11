﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TeacherLeague.Models;
using TeacherLeague.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeacherLeague.PageModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class EditAccountInfoPageModel : BaseAccountDetailPageModel
    {
        public ICommand SaveChangesCommand { get; private set; }

        public EditAccountInfoPageModel(IUserService userService) : base (userService)
        {

            SaveChangesCommand = new Command(async () => await SaveChanges());
            _user = new User();
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            _user = (User)initData;
        }

        async Task FetchUser()
        {
            _user = await _userService.GetUserByEmailAsync(Application.Current.Properties["Email"].ToString());
        }

        async Task SaveChanges()
        {
            await _userService.UpdateUserAsync(_user);
            await CoreMethods.PopPageModel();
        }

    }
}

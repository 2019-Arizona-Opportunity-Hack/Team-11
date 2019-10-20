using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using TeacherLeague.Models;
using TeacherLeague.Repositories;
using TeacherLeague.Services;
using Xamarin.Forms;

namespace TeacherLeague.PageModels
{
    public class HomePageModel : FreshBasePageModel
    {
        IUserService userService;


        public HomePageModel(IUserService service)
        {
            userService = service;
        }
    }
}

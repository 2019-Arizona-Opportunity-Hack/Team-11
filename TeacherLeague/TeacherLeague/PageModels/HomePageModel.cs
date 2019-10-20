using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Video> recentVideos;


        public HomePageModel(IUserService service)
        {
            userService = service;
            
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            recentVideos = new ObservableCollection<Video>();
            recentVideos.Add(new Video { User = "Joe", Rating = 10 });
            recentVideos.Add(new Video { User = "Joe", Rating = 10 });
            recentVideos.Add(new Video { User = "Joe", Rating = 10 });
        }
    }
}

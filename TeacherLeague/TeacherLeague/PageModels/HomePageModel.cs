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
        public ObservableCollection<Video> RecentVideos { get; set; }
        public ObservableCollection<LessonPlan> RecentLessonPlans { get; set; }


        public HomePageModel()
        {
            RecentVideos = new ObservableCollection<Video>();
            RecentVideos.Add(new Video { User = "Joe", Rating = 10, Url = "https://picsum.photos/300/300" });
            RecentVideos.Add(new Video { User = "Joe", Rating = 10, Url = "https://picsum.photos/300/300" });
            RecentVideos.Add(new Video { User = "Joe", Rating = 10, Url = "https://picsum.photos/300/300" });

            RecentLessonPlans = new ObservableCollection<LessonPlan>();
            RecentLessonPlans.Add(new LessonPlan { User = "Jared", Content = "How to Add 1 + 1", Subject = "Math", Title = "Add 1+1", Url = "http://lorempixel.com/300/300/sports/Dummy-Text" });
            RecentLessonPlans.Add(new LessonPlan { User = "Jared", Content = "How to Add 1 + 1", Subject = "Math", Title = "Add 1+1", Url = "http://lorempixel.com/300/300/sports/Dummy-Text" });
            RecentLessonPlans.Add(new LessonPlan { User = "Jared", Content = "How to Add 1 + 1", Subject = "Math", Title = "Add 1+1", Url = "http://lorempixel.com/300/300/sports/Dummy-Text" });
        }

    }
}

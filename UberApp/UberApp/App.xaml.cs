using System;
using System.IO;
using UberApp.Models;
using Xamarin.Forms;

[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "Montserrat-Bold")]
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
[assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
[assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
[assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace UberApp
{
    public partial class App : Application
    {
        private static DatabaseSqLite _database;

        public static DatabaseSqLite Database
        {
            get
            {
                if(_database==null)
                {
                    _database = new DatabaseSqLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"uber.db" ));
                }

                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

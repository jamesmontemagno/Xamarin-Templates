using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace BlankAppEmbedded
{
    public static class App
    {
        
        public static Page StartPage { get; }
        static App()
        {
            StartPage = new MainPage();
        }
    }
}

using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using BlankAppEmbedded.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace BlankAppEmbedded.Droid.Helpers
{
    public class AppNavigation : IAppNavigation
    {
        int count;
        public static Activity Activity { get; set; }
        public static FragmentManager Manager { get; set; }
        public static int ResourceId { get; set; }

        public void Pop()
        {
            Manager.PopBackStackImmediate();
            SetTitle();
            SetHomeEnabled();
        }

        public void Push(Page page)
        {            
            var frag = page.CreateFragment(Activity);

            Manager.BeginTransaction()
                   .SetTransition(FragmentTransit.FragmentOpen)
                   .Replace(ResourceId, frag, page.Title)
                   .AddToBackStack(count++.ToString())
                   .SetBreadCrumbTitle(page.Title)
                   .Commit();

            Manager.ExecutePendingTransactions();


            SetHomeEnabled();
            SetTitle();
        }

        void SetTitle()
        {
            if (Activity != null && Activity is AppCompatActivity)
                ((AppCompatActivity)Activity).SupportActionBar.Title = GetTitle();
        }

        void SetHomeEnabled()
        {
            if (Activity != null && Activity is AppCompatActivity)
                ((AppCompatActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(Manager.BackStackEntryCount > 1);
        }

        string GetTitle()
        {
            if (Manager.BackStackEntryCount == 0)
                return string.Empty;

            return Manager.GetBackStackEntryAt(Manager.BackStackEntryCount - 1)?.BreadCrumbTitleFormatted?.ToString() ?? string.Empty;
        }
    }
}

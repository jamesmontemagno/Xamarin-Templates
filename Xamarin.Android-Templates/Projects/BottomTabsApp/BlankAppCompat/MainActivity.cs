using Android.App;
using Android.OS;
using TabsApp.Fragments;

using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace TabsApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);

            }

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            

            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = Fragment1.NewInstance();
                    break;
                case Resource.Id.menu_audio:
                    fragment = Fragment2.NewInstance();
                    break;
                case Resource.Id.menu_video:
                    fragment = Fragment3.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }
    }
}


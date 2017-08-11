using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

using Toolbar = Android.Support.V7.Widget.Toolbar;

using Xamarin.Forms;

using BlankAppEmbedded.Droid.Helpers;
using BlankAppEmbedded.Interfaces;
using Android.Support.V4.App;
using Android.Views;

namespace BlankAppEmbedded.Droid
{
    [Activity(Label = "BlankAppEmbedded", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Setup MainView
            var linear = new LinearLayout(this);
            linear.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);
            linear.Orientation = Orientation.Vertical;

            //Create toolbar
            var inflated = LayoutInflater.Inflate(Resource.Layout.Toolbar, null);
            var toolbar = inflated.FindViewById<Toolbar>(Resource.Id.toolbar);

            linear.AddView(toolbar);

            var frame = new FrameLayout(this);
            frame.LayoutParameters = linear.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);

            frame.Id = 100;

            linear.AddView(frame);

            SetContentView(linear);

            SetSupportActionBar(toolbar);

            //Setup navigation
            if (!Forms.IsInitialized)
                Forms.Init(this, savedInstanceState);

            DependencyService.Register<IAppNavigation, AppNavigation>();

            AppNavigation.Manager = FragmentManager;
            AppNavigation.ResourceId = 100;
            
            var appNavigation = DependencyService.Get<IAppNavigation>();

            appNavigation.Push(App.StartPage);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DependencyService.Get<IAppNavigation>().Pop();
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}


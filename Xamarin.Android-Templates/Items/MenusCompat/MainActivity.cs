using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.View;

namespace MenusCompat
{
  [Activity(Label = "Menus Compat", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : ActionBarActivity
  {
    int count = 1;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.Main);

      // Get our button from the layout resource,
      // and attach an event to it
      Button button = FindViewById<Button>(Resource.Id.MyButton);

      button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
    }

    Android.Support.V7.Widget.SearchView searchView;
    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      //change menu_compat_search to your name
      this.MenuInflater.Inflate(Resource.Menu.menu_compat_search, menu);

      var searchItem = menu.FindItem(Resource.Id.action_search);

      var provider = MenuItemCompat.GetActionView(searchItem);

      searchView = provider.JavaCast<Android.Support.V7.Widget.SearchView>();

      searchView.QueryTextSubmit += (sender, args) =>
      {
        Toast.MakeText(this, "You searched: " + args.Query, ToastLength.Short).Show();
      };


      return base.OnCreateOptionsMenu(menu);
    }


    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      switch (item.ItemId)
      {
        case Resource.Id.action_edit:
          Toast.MakeText(this, "You pressed edit action!", ToastLength.Short).Show();
          break;
        case Resource.Id.action_save:
          Toast.MakeText(this, "You pressed save action!", ToastLength.Short).Show();
          break;
      }
      return base.OnOptionsItemSelected(item);
    }
  }
}


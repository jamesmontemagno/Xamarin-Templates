using Android.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Android.OS;
using NavigationDrawer.Fragments;
using NavigationDrawer.Helpers;
using Android.Content.Res;

namespace NavigationDrawer
{
  [Activity(Label = "NavigationDrawer", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/ThemeLight")]
  public class MainActivity : Activity
  {
    private DrawerToggle drawerToggle;
    private string drawerTitle;
    private string currentSectionTitle;

    private DrawerLayout drawerLayout;
    private ListView drawerListView;
    private string[] sections;
    private int lastSelectedSection = -1;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.main);

      sections = Resources.GetTextArray(Resource.Array.drawer_sections);

      currentSectionTitle = drawerTitle = Title;

      drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
      drawerListView = FindViewById<ListView>(Resource.Id.left_drawer);

      drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, sections);

      drawerListView.ItemClick += (sender, args) => ListItemClicked(args.Position);


      drawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);



      //DrawerToggle is the animation that happens with the indicator next to the actionbar
      drawerToggle = new DrawerToggle(this, drawerLayout,
                                                Resource.Drawable.ic_drawer_light,
                                                Resource.String.drawer_open,
                                                Resource.String.drawer_close);

      //Display the current fragments title and update the options menu
      drawerToggle.DrawerClosed += (o, args) =>
      {
        ActionBar.Title = currentSectionTitle;
        InvalidateOptionsMenu();
      };

      //Display the drawer title and update the options menu
      drawerToggle.DrawerOpened += (o, args) =>
      {
        ActionBar.Title = drawerTitle;
        InvalidateOptionsMenu();
      };

      //Set the drawer lister to be the toggle.
      drawerLayout.SetDrawerListener(drawerToggle);



      //If first time you will want to go ahead and click first item.
      if (savedInstanceState == null)
      {
        ListItemClicked(0);
      }


      ActionBar.SetDisplayHomeAsUpEnabled(true);
      ActionBar.SetHomeButtonEnabled(true);
    }

    protected override void OnPostCreate(Bundle savedInstanceState)
    {
      base.OnPostCreate(savedInstanceState);
      drawerToggle.SyncState();
    }

    public override void OnConfigurationChanged(Configuration newConfig)
    {
      base.OnConfigurationChanged(newConfig);
      drawerToggle.OnConfigurationChanged(newConfig);
    }

    // Pass the event to ActionBarDrawerToggle, if it returns
    // true, then it has handled the app icon touch event
    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      if (drawerToggle.OnOptionsItemSelected(item))
        return true;

      return base.OnOptionsItemSelected(item);
    }

    private void ListItemClicked(int position)
    {
      if (lastSelectedSection == position)
        return;

      lastSelectedSection = position;

      Fragment fragment = null;
      
      switch (position)
      {
        case 0:
          fragment = Fragment1.NewInstance();
          break;
        case 1:
          fragment = Fragment2.NewInstance();
          break;
      }


      FragmentManager.BeginTransaction()
          .Replace(Resource.Id.content_frame, fragment)
          .Commit();

      drawerListView.SetItemChecked(position, true);
      ActionBar.Title = currentSectionTitle = sections[position];
      drawerLayout.CloseDrawer(drawerListView);
    }





    public override bool OnPrepareOptionsMenu(IMenu menu)
    {

      var drawerOpen = drawerLayout.IsDrawerOpen(drawerListView);
      
      //When we open the drawer we usually do not want to show any menu options
      for (int i = 0; i < menu.Size(); i++)
        menu.GetItem(i).SetVisible(!drawerOpen);


      return base.OnPrepareOptionsMenu(menu);
    }
  }
}


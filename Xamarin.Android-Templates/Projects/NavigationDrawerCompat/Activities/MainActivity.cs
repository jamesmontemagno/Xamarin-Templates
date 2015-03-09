using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using NavDrawer.Fragments;
using NavDrawer.Helpers;
using Android.Support.V7.App;
using NavDrawer.Adapters;
using Android.Support.V4.View;

namespace NavDrawer.Activities
{
	[Activity (Label = "Home", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
	public class MainActivity : BaseActivity
	{
        
		private MyActionBarDrawerToggle drawerToggle;
		private string drawerTitle;
		private string title;

		private DrawerLayout drawerLayout;
		private ListView drawerListView;
    private DrawerMenuAdapter adapter;

		protected override int LayoutResource {
			get {
				return Resource.Layout.main;
			}
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);


			this.title = this.drawerTitle = this.Title;
			this.drawerLayout = this.FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			this.drawerListView = this.FindViewById<ListView> (Resource.Id.left_drawer);


			//Create Adapter for drawer List
      this.drawerListView.Adapter = adapter = new DrawerMenuAdapter(this);

			//Set click handler when item is selected
			this.drawerListView.ItemClick += (sender, args) => ListItemClicked (args.Position);

			//Set Drawer Shadow
			this.drawerLayout.SetDrawerShadow (Resource.Drawable.drawer_shadow_dark, (int)GravityCompat.Start);



			//DrawerToggle is the animation that happens with the indicator next to the actionbar
			this.drawerToggle = new MyActionBarDrawerToggle (this, this.drawerLayout,
				this.Toolbar,
				Resource.String.drawer_open,
				Resource.String.drawer_close);

			//Display the current fragments title and update the options menu
			this.drawerToggle.DrawerClosed += (o, args) => {
				this.SupportActionBar.Title = this.title;
				this.SupportInvalidateOptionsMenu ();
			};

			//Display the drawer title and update the options menu
			this.drawerToggle.DrawerOpened += (o, args) => {
				this.SupportActionBar.Title = this.drawerTitle;
        this.SupportInvalidateOptionsMenu();
			};

			//Set the drawer lister to be the toggle.
			this.drawerLayout.SetDrawerListener (this.drawerToggle);

            

			//if first time you will want to go ahead and click first item.
			if (savedInstanceState == null) {
				ListItemClicked (0);
			}
		}

    int oldPosition = -1;
		private void ListItemClicked (int position)
		{
      //this way we don't load twice, but you might want to modify this a bit.
      if (position == oldPosition)
        return;

      oldPosition = position;
      
			Android.Support.V4.App.Fragment fragment = null;
			switch (position) {
			case 0:
          fragment = Fragment1.NewInstance();
				break;
			case 1:
          fragment = Fragment2.NewInstance();
				break;
			}

			SupportFragmentManager.BeginTransaction ()
				.Replace (Resource.Id.content_frame, fragment)
				.Commit ();

			this.drawerListView.SetItemChecked (position, true);
      SupportActionBar.Title = this.title = adapter.GetTitle(position);
			this.drawerLayout.CloseDrawers();
		}

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{

			var drawerOpen = this.drawerLayout.IsDrawerOpen((int)GravityCompat.Start);
			//when open don't show anything
			for (int i = 0; i < menu.Size (); i++)
				menu.GetItem (i).SetVisible (!drawerOpen);


			return base.OnPrepareOptionsMenu (menu);
		}

		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			this.drawerToggle.SyncState ();
		}

		public override void OnConfigurationChanged (Configuration newConfig)
		{
			base.OnConfigurationChanged (newConfig);
			this.drawerToggle.OnConfigurationChanged (newConfig);
		}

		// Pass the event to ActionBarDrawerToggle, if it returns
		// true, then it has handled the app icon touch event
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (this.drawerToggle.OnOptionsItemSelected (item))
				return true;

			return base.OnOptionsItemSelected (item);
		}



	}
}


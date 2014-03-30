using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NavigationDrawer.Fragments
{
  public class Fragment1 : Fragment
  {
    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your fragment here
    }

    public static Fragment1 NewInstance()
    {
      var frag1 = new Fragment1 { Arguments = new Bundle() };
      return frag1;
    }


    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      var ignored = base.OnCreateView(inflater, container, savedInstanceState);
      return inflater.Inflate(Resource.Layout.fragment1, null);
    }
  }
}
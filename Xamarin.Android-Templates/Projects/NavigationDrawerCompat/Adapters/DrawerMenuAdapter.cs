using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace NavDrawer.Adapters
{

  class MyViewHolder : Java.Lang.Object
  {
    public TextView Title { get; set; }
  }

  class DrawerMenuAdapter : BaseAdapter
  {
    Tuple<int, string>[] sections;

    Context context;

    public DrawerMenuAdapter(Context context)
    {
      this.context = context;

      var names = context.Resources.GetStringArray(Resource.Array.sections);
      var icons = context.Resources.GetStringArray(Resource.Array.sections_icons);

      if (names.Length != icons.Length)
        throw new ArgumentException("Names and Icons must match in length. Check your arrays.xml");

      sections = new Tuple<int,string>[names.Length];

      var imgs = context.Resources.ObtainTypedArray(Resource.Array.sections_icons);
      for(int i = 0; i < names.Length; i++)
      {

        sections[i] = Tuple.Create(imgs.GetResourceId(i, -1), names[i]);
      }
      imgs.Recycle();
    }

    public string GetTitle(int position)
    {
      return sections[position].Item2;
    }

    public override Java.Lang.Object GetItem(int position)
    {
      return new Java.Lang.String(sections[position].Item2);
    }

    public override long GetItemId(int position)
    {
      return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      var view = convertView;
      MyViewHolder holder = null;

      if (view != null)
        holder = view.Tag as MyViewHolder;

      if (holder == null)
      {
        holder = new MyViewHolder();
        var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
        view = inflater.Inflate(Resource.Layout.item_menu, parent, false);
        holder.Title = view.FindViewById<TextView>(Resource.Id.text);
        view.Tag = holder;

      }

      if (position == 0 && convertView == null)
        holder.Title.SetTypeface(holder.Title.Typeface, TypefaceStyle.Bold);
      else
        holder.Title.SetTypeface(holder.Title.Typeface, TypefaceStyle.Normal);


      holder.Title.Text = sections[position].Item2;
      holder.Title.SetCompoundDrawablesWithIntrinsicBounds(sections[position].Item1, 0, 0, 0);

      return view;
    }

    public override int Count
    {
      get
      {
        return sections.Length;
      }
    }

    public override bool IsEnabled(int position)
    {
      return true;
    }

    public override bool AreAllItemsEnabled()
    {
      return false;
    }
  }
}
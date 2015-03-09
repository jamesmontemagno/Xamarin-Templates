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

namespace MenusCompat
{
  class Adapter : BaseAdapter
  {

    Context context;

    public Adapter(Context context)
    {
      this.context = context;

    }


    public override Java.Lang.Object GetItem(int position)
    {
      return position;
    }

    public override long GetItemId(int position)
    {
      return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
      var view = convertView;
      AdapterViewHolder holder = null;

      if (view != null)
        holder = view.Tag as AdapterViewHolder;

      if (holder == null)
      {
        holder = new AdapterViewHolder();
        var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
        //replace with your item and your holder items
        //comment back in
        //view = inflater.Inflate(Resource.Layout.item, parent, false);
        //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
        view.Tag = holder;
      }

   
      //fill in your items
      //holder.Title.Text = "new text here";
     
      return view;
    }

    //Fill in cound here, currently 0
    public override int Count
    {
      get
      {
        return 0;
      }
    }

  }

  class AdapterViewHolder : Java.Lang.Object
  {
    //Your adapter views to re-use
    //public TextView Title { get; set; }
  }
}
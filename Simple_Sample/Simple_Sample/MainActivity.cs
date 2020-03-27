using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.Buttons;

namespace Simple_Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        bool skip = false;
        SfCheckBox selectAll, pepperoni, beef, mushroom, onion;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            LinearLayout linearLayout = new LinearLayout(this);
            linearLayout.Orientation = Orientation.Vertical;
            selectAll = new SfCheckBox(this);
            selectAll.StateChanged += SelectAll_StateChanged;
            selectAll.Text = "Select All";
            linearLayout.AddView(selectAll);
            pepperoni = new SfCheckBox(this);
            pepperoni.StateChanged += CheckBox_StateChanged;
            pepperoni.Text = "Pepperoni";
            linearLayout.AddView(pepperoni);
            beef = new SfCheckBox(this);
            beef.StateChanged += CheckBox_StateChanged;
            beef.Text = "Beef";
            beef.Checked = true;
            linearLayout.AddView(beef);
            mushroom = new SfCheckBox(this);
            mushroom.StateChanged += CheckBox_StateChanged;
            mushroom.Text = "Mushrooms";
            linearLayout.AddView(mushroom);
            onion = new SfCheckBox(this);
            onion.StateChanged += CheckBox_StateChanged;
            onion.Text = "Onions";
            onion.Checked = true;
            linearLayout.AddView(onion);
            SetContentView(linearLayout);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        private void SelectAll_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (!skip)
            {
                skip = true;
                pepperoni.Checked = beef.Checked = mushroom.Checked = onion.Checked = e.IsChecked;
                skip = false;
            }
        }

        private void CheckBox_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (!skip)
            {
                skip = true;
                if (pepperoni.Checked.Value && beef.Checked.Value && mushroom.Checked.Value && onion.Checked.Value)
                    selectAll.Checked = true;
                else if (!pepperoni.Checked.Value && !beef.Checked.Value && !mushroom.Checked.Value && !onion.Checked.Value)
                    selectAll.Checked = false;
                else
                    selectAll.Checked = null;
                skip = false;
            }
        }

    }
}


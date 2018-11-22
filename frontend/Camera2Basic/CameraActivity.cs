using System;

using Android.App;
using Android.OS;

namespace Camera2Basic
{
    [Activity(Label = "Epicenter Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class CameraActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.Hide();
            SetContentView(Resource.Layout.activity_camera);

            if (bundle == null)
            {
                FragmentManager.BeginTransaction().Replace(Resource.Id.container, new CameraFragment()).Commit();
            }
        }
    }
}



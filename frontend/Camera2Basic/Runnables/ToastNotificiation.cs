using Android.Content;
using Android.Widget;

namespace Camera2Basic
{
    public class ToastNotification : Java.Lang.Object, Java.Lang.IRunnable
    {
        private string _text;
        private Context _context;

        public ToastNotification(Context context, string text)
        {
            _context = context;
            _text = text;
        }

        public void Run()
        {
            Toast.MakeText(_context, _text, ToastLength.Short).Show();
        }
    }
}
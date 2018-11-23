using Android.Media;
using Camera2Basic.Runnables;
using Plugin.LocalNotifications;
namespace Camera2Basic.Listeners
{
    public delegate void NotificationDelegate(string text);

    public class ImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
    {
        private readonly CameraFragment _owner;

        public ImageAvailableListener(CameraFragment fragment)
        {
            _owner = fragment;
        }

        public void OnImageAvailable(ImageReader reader)
        {
            Image image = reader.AcquireNextImage();
            //saves the image to a file (optional)
            _owner.BackgroundHandler.Post(new ImageSaver(image, _owner.ImageFile));

            ImageUploader uploader = new ImageUploader(image);
            uploader.UploadComplete += (json) => { CrossLocalNotifications.Current.Show("title", "body"); };
            _owner.BackgroundHandler.Post(new ImageUploader(image));
        }
    }
}
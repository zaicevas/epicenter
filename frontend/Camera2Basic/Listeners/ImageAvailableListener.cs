using Android.Media;
using Camera2Basic.Runnables;
using Camera2Basic.Services;

namespace Camera2Basic.Listeners
{
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
            _owner.BackgroundHandler.Post(new ImageSaver(image, _owner.ImageFile));
            _owner.BackgroundHandler.Post(new ImageUploader(image));
        }
    }
}
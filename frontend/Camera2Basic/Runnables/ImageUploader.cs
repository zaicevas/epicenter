using Android.Media;
using Camera2Basic.Services;

namespace Camera2Basic.Runnables
{
    public class ImageUploader : Java.Lang.Object, Java.Lang.IRunnable
    {
        public Image Image { get; set; }

        private ImageUploadService imageUploadService;

        public ImageUploader(Image image)
        {
            Image = image;
            imageUploadService = new ImageUploadService();
        }

        public void Run()
        {
            imageUploadService.Upload(Image);
        }
    }
}
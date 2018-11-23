using Android.Media;
using Camera2Basic.Services;
using Newtonsoft.Json.Linq;

namespace Camera2Basic.Runnables
{
    public delegate void ResponseDelagate(JObject text);

    public class ImageUploader : Java.Lang.Object, Java.Lang.IRunnable
    {
        public event ResponseDelagate UploadComplete;
        public Image Image { get; set; }

        private ImageUploadService imageUploadService;

        public ImageUploader(Image image)
        {
            Image = image;
            imageUploadService = new ImageUploadService();
        }

        public async void Run()
        {
            JObject response = await imageUploadService.Upload(Image) as JObject;
            UploadComplete?.Invoke(response);
        }
    }
}
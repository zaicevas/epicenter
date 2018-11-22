using Android.Media;
using Camera2Basic.ExtentionMethods;
using Java.IO;
using Java.Lang;

namespace Camera2Basic.Runnables
{
    // Saves a JPEG {@link Image} into the specified {@link File}.
    public class ImageSaver : Object, IRunnable
    {
        // The JPEG image
        private readonly Image _image;

        // The file we save the image into.
        private readonly File _imageFile;

        public ImageSaver(Image image, File imageFile)
        {
            _image = image ?? throw new System.ArgumentNullException(nameof(image));
            _imageFile = imageFile ?? throw new System.ArgumentNullException(nameof(imageFile));
        }

        public void Run()
        {
            byte[] bytes = _image.ByteArray();
            using (var output = new FileOutputStream(_imageFile))
            {
                try
                {
                    output.Write(bytes);
                }
                catch (IOException e)
                {
                    e.PrintStackTrace();
                }
                finally
                {
                    _image.Close();
                }
            }
        }
    }
}
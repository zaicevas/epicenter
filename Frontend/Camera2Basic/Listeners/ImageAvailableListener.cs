using Android.Media;
using Java.IO;
using Java.Lang;
using Java.Nio;

namespace Camera2Basic.Listeners
{
    public class ImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
    {
        private readonly Camera2BasicFragment _owner;
        private readonly File _file;

        public ImageAvailableListener(Camera2BasicFragment fragment)
        {
            if (fragment == null)
                throw new System.ArgumentNullException(nameof(fragment));

            _owner = fragment;
        }


        //public File File { get; private set; }
        //public Camera2BasicFragment Owner { get; private set; }

        public void OnImageAvailable(ImageReader reader)
        {
            _owner._backgroundHandler.Post(new ImageSaver(reader.AcquireNextImage(), _owner.ImageFile));
        }

        // Saves a JPEG {@link Image} into the specified {@link File}.
        private class ImageSaver : Java.Lang.Object, IRunnable
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
                ByteBuffer buffer = _image.GetPlanes()[0].Buffer;
                byte[] bytes = new byte[buffer.Remaining()];
                buffer.Get(bytes);
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
}
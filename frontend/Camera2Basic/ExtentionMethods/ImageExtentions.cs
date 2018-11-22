using Android.Media;
using Java.Nio;

namespace Camera2Basic.ExtentionMethods
{
    public static class ImageExtentions
    {
        public static byte[] ByteArray(this Image image)
        {
            ByteBuffer buffer = image.GetPlanes()[0].Buffer;
            byte[] bytes = new byte[buffer.Remaining()];
            buffer.Get(bytes);
            return bytes;
        }
    }
}
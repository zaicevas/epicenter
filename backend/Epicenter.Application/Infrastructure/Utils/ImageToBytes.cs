using System.IO;

namespace Epicenter.Application.Infrastructure.Utils
{
    public static class ImageToBytes
    {
        //Might be uneccessary as we probably won't use files
        public static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}

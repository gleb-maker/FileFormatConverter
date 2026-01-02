using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;

namespace FileFormatConverter.Services
{
    public static class ImageService
    {
        public static void PngToJpg(string path)
        {
            string output = Path.ChangeExtension(path, ".jpg");

            using var image = Image.Load(path);
            image.Save(output, new JpegEncoder());
        }
    }
}

using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Utilities
{
    //Note: PM> Install-Package SkiaSharp

    /// <summary>
    /// View Model used as return type for the shrinkImage() method 
    /// that allows you to specify image format (Mime Type) and quality
    /// </summary>
    public class ImageVM
    {

        public Byte[] Content { get; set; }

        public string MimeType { get; set; }

    }

    public static class ResizeImage
    {

        /// <summary>
        /// Code by David Stovell from ideas I found in various posts on the internet.
        /// NOTE: This code maintains aspect ratio so for example, a tall, narrow image will 
        ///      shrink until the height matches max_height but the width will be smaller then max_width.
        /// NOTE: If the image is smaller it will not be enlarged.
        /// USE THIS METHOD: if you just want a WebP Image at full quality without extra parameters
        /// </summary>
        /// <param name="originalImage">Byte Array from the uploaded file</param>
        /// <param name="max_height">Default 100</param>
        /// <param name="max_width">Default 120</param>
        /// <returns>Byte Array of the resized image - MIME Type "image/webp"</returns>
        public static Byte[] shrinkImageWebp(Byte[] originalImage,
            int max_height = 100, int max_width = 120)
        {
            using SKMemoryStream sourceStream = new SKMemoryStream(originalImage);
            using SKCodec codec = SKCodec.Create(sourceStream);
            sourceStream.Seek(0);

            using SKImage image = SKImage.FromEncodedData(SKData.Create(sourceStream));
            int newHeight = image.Height;
            int newWidth = image.Width;

            if (max_height > 0 && newHeight > max_height)
            {
                double scale = (double)max_height / newHeight;
                newHeight = max_height;
                newWidth = (int)Math.Floor(newWidth * scale);
            }

            if (max_width > 0 && newWidth > max_width)
            {
                double scale = (double)max_width / newWidth;
                newWidth = max_width;
                newHeight = (int)Math.Floor(newHeight * scale);
            }

            var info = codec.Info.ColorSpace.IsSrgb ? new SKImageInfo(newWidth, newHeight) : new SKImageInfo(newWidth, newHeight, SKImageInfo.PlatformColorType, SKAlphaType.Premul, SKColorSpace.CreateSrgb());
            using SKSurface surface = SKSurface.Create(info);
            using SKPaint paint = new SKPaint();
            // High quality without antialiasing
            paint.IsAntialias = true;
            paint.FilterQuality = SKFilterQuality.High;

            // Draw the bitmap to fill the surface
            surface.Canvas.Clear(SKColors.White);
            var rect = new SKRect(0, 0, newWidth, newHeight);
            surface.Canvas.DrawImage(image, rect, paint);
            surface.Canvas.Flush();

            using SKImage newImage = surface.Snapshot();
            using SKData newImageData = newImage.Encode(SKEncodedImageFormat.Webp, 100);

            return newImageData.ToArray();
        }


        /// <summary>
        /// Code by David Stovell from ideas I found in various posts on the internet.
        /// NOTE: This code maintains aspect ratio so for example, a tall, narrow image will 
        ///      shrink until the height matches max_height but the width will be smaller then max_width.
        /// NOTE: If the image is smaller it will not be enlarged.
        /// USE THIS METHOD: If you want a different image format and mime type or lower quality
        /// </summary>
        /// <param name="originalImage">Byte Array from the uploaded file</param>
        /// <param name="max_height">Default 100</param>
        /// <param name="max_width">Default 120</param>
        /// <param name="selectedFormat">Default format is set to Webp but you can change that with this parameter
        /// NOTE: MAKE SURE YOUR MIME TYPE MATCHES.  It would be image/webp for the default.</param>
        /// <param name="quality">Value from 1 to 100 for quality factor.  Default is 100 for best quality.</param>
        /// <returns>Object of type ImageVM, containing the Byte Array and the new MimeType</returns>
        public static ImageVM shrinkImage(Byte[] originalImage,
            int max_height = 100, int max_width = 120,
            SKEncodedImageFormat selectedFormat = SKEncodedImageFormat.Webp, int quality = 100)
        {
            using SKMemoryStream sourceStream = new SKMemoryStream(originalImage);
            using SKCodec codec = SKCodec.Create(sourceStream);
            sourceStream.Seek(0);

            using SKImage image = SKImage.FromEncodedData(SKData.Create(sourceStream));
            int newHeight = image.Height;
            int newWidth = image.Width;

            if (max_height > 0 && newHeight > max_height)
            {
                double scale = (double)max_height / newHeight;
                newHeight = max_height;
                newWidth = (int)Math.Floor(newWidth * scale);
            }

            if (max_width > 0 && newWidth > max_width)
            {
                double scale = (double)max_width / newWidth;
                newWidth = max_width;
                newHeight = (int)Math.Floor(newHeight * scale);
            }

            var info = codec.Info.ColorSpace.IsSrgb ? new SKImageInfo(newWidth, newHeight) : new SKImageInfo(newWidth, newHeight, SKImageInfo.PlatformColorType, SKAlphaType.Premul, SKColorSpace.CreateSrgb());
            using SKSurface surface = SKSurface.Create(info);
            using SKPaint paint = new SKPaint();
            // High quality without antialiasing
            paint.IsAntialias = true;
            paint.FilterQuality = SKFilterQuality.High;

            // Draw the bitmap to fill the surface
            surface.Canvas.Clear(SKColors.White);
            var rect = new SKRect(0, 0, newWidth, newHeight);
            surface.Canvas.DrawImage(image, rect, paint);
            surface.Canvas.Flush();

            using SKImage newImage = surface.Snapshot();
            using SKData newImageData = newImage.Encode(selectedFormat, quality);
            //Prepare the return object
            ImageVM imageVM = new ImageVM
            {
                Content = newImageData.ToArray(),
                MimeType = selectedFormat switch
                {
                    SKEncodedImageFormat.Bmp => "image/bmp",
                    SKEncodedImageFormat.Gif => "image/gif",
                    SKEncodedImageFormat.Ico => "image/vnd.microsoft.icon",
                    SKEncodedImageFormat.Jpeg => "image/jpeg",
                    SKEncodedImageFormat.Png => "image/png",
                    SKEncodedImageFormat.Wbmp => "image/wbmp",
                    SKEncodedImageFormat.Webp => "image/webp",
                    SKEncodedImageFormat.Pkm => "image/octet-stream",
                    SKEncodedImageFormat.Ktx => "image/ktx",
                    SKEncodedImageFormat.Astc => "image/png",
                    SKEncodedImageFormat.Dng => "image/DNG",
                    SKEncodedImageFormat.Heif => "image/heif",
                    _ => "image/jpeg",
                }
            };

            return imageVM;
        }
    }
}

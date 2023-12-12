using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Ads.Core.Utilities.Images
{
  public class ImageProcessor : IImageProcessor
  {
    private readonly IWebHostEnvironment _environment;

    public ImageProcessor(IWebHostEnvironment environment)
    {
      _environment = environment;
    }

    public async Task<string> SaveImageAsync(IFormFile file, int advertId, string path)
    {
      if (file.ContentType.StartsWith("image/"))
      {
        // Check file size (in bytes), for example, limit it to 1000 KB
        const int maxFileSize = 1000 * 1024;

        if (file.Length > maxFileSize)
        {
          // File size exceeds the limit, handle accordingly (e.g., return an error message)
          throw new InvalidOperationException("File size exceeds the limit. Please upload a file smaller than 1000 KB.");
          
        }

        // Resize the image before saving
        using (var stream = new MemoryStream())
        {
          await file.CopyToAsync(stream);

          stream.Seek(0, SeekOrigin.Begin);

          using (var image = Image.Load(stream))
          {
            image.Mutate(x => x
               .Resize(new ResizeOptions
               {
                 Size = new Size(610, 400),
                 Mode = ResizeMode.Max // Ratio sabit kalicak. Buyuk olani aliyor.
               }));

            // Save the resized image
            var fileName = $"{advertId}_{Path.GetFileName(file.FileName)}";
            var savePath = Path.Combine(_environment.WebRootPath, path, fileName);



            image.Save(savePath);

            return fileName;
            

            //AdvertImage saveImage = new AdvertImage() { ImagePath = savePath };

            //dto.AdvertAddDto.AdvertImages.Add(saveImage);

          }
        }
      }
      else
      {
        throw new InvalidOperationException("File is not an image");
      }



    }
  }
}





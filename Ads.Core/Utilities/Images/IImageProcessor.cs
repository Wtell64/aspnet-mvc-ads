using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Core.Utilities.Images
{
  public interface IImageProcessor
  {
    Task<string> SaveImageAsync(IFormFile file, int advertId);
  }
}

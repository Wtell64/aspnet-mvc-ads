

using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FutureCafe.Core.Utilities.Extensions
{
  public static class ValidationResultExtension
  {
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
    {
    // Controllerda validasyon sonucunu model state e atip sayfaya dogru mesaji gonderimini saglar
      modelState.Clear();
      foreach (var error in result.Errors)
      {
        modelState.AddModelError(error.PropertyName, error.ErrorMessage);
      }
    }
  }
}
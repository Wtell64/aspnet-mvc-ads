using System.ComponentModel.DataAnnotations;

namespace Ads.Business.Extentions
{
	public class MustBeTrueAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null) return false;
			if (value is bool b) return b;

			throw new InvalidOperationException("Can only be used on boolean properties.");
		}
	}
}

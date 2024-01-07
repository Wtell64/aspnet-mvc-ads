using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Entities.Concrete.Enums
{
	public enum AdvertConditionEnum
	{
		[Description("Belirtilmemiş")] None = 0,
		[Description("Fabrikadan Yeni Çıkmış")] FactoryNew = 1,
		[Description("Az Kullanılmış")] MinimalUsed = 2,
		[Description("Eskimiş")] WellWorn = 3
	}
}

using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ads.Dal.Configurations
{
	public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
	{


		public void Configure(EntityTypeBuilder<Advert> builder)
		{
			// Configure properties
			builder.Property(a => a.Title).IsRequired().HasColumnType("nvarchar(200)");
			builder.Property(a => a.Description).IsRequired().HasColumnType("ntext");
			builder.Property(a => a.Price).IsRequired();
			builder.HasKey(c => c.Id);

			builder.HasMany(a => a.AdvertComments).WithOne(ac => ac.Advert).HasForeignKey(ac => ac.AdvertId).OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
					new Advert { Id = 1, Title = "Siyah Laptop", Price = 140, UserId = 3, Description = "Siyah az kullanılmıs laptop", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 2, Title = "Beyaz Laptop", Price = 250, UserId = 4, Description = "Beyaz laptop. İhtiyacım olduğu için satıyorum", ConditionEnum = AdvertConditionEnum.WellWorn },
					new Advert { Id = 3, Title = "Iphone Telefon", Price = 340, UserId = 5, Description = "2013 model İphone", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 4, Title = "Android Telefon", Price = 240, UserId = 7, Description = "Android telefon en iyi telefondur", ConditionEnum = AdvertConditionEnum.WellWorn },
					new Advert { Id = 5, Title = "Android Tablet", Price = 220, UserId = 4, Description = "Samsung Android Tablet. Sahibinden satılıktır", ConditionEnum = AdvertConditionEnum.MinimalUsed },
					new Advert { Id = 6, Title = "İPhone Tablet IPad", Price = 180, UserId = 6, Description = "Kardeşimin ipadini satıyoruz. Üstünde az çizik vardır", ConditionEnum = AdvertConditionEnum.WellWorn },
					new Advert { Id = 7, Title = "Led Ekran", Price = 540, UserId = 6, Description = "Led ekran televizyon. 20 cm e 50 cm. Az kullanılmış", ConditionEnum = AdvertConditionEnum.MinimalUsed },
					new Advert { Id = 8, Title = "Pc Ekranı", Price = 40, UserId = 3, Description = "17 inch ekranımı satıyorum", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 9, Title = "Ayşin Kafe", Price = 400, UserId = 5, Description = "Ayşin kafede ev yemekleri seni çağırıyor", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 10, Title = "Cafe Paranoma", Price = 470, UserId = 6, Description = "Kafe Paranoma, dünyaca ünlü kahve çeşitleri burada", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 11, Title = "Mcdonalds", Price = 200, UserId = 4, Description = "Mcdonals seni çağırıyor", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 12, Title = "Tostçu Erol", Price = 120, UserId = 3, Description = "Tostumu yiyen başka bişey yemez", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 13, Title = "Restoran Eskargo", Price = 30, UserId = 6, Description = "Her tür yemek bulunur", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 14, Title = "Yeşim Restoran", Price = 140, UserId = 5, Description = "Yeşim restoranda her şey var", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 15, Title = "Ayşe Teyze Restoran", Price = 340, UserId = 6, Description = "Yemekler bizden sorulur", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 16, Title = "Bodrum Ev Yemekleri", Price = 120, UserId = 7, Description = "Bodrum un eşsiz yemek lezzetleri burada", ConditionEnum = AdvertConditionEnum.None },
					new Advert { Id = 17, Title = "20 metrekare, denize karşı ", Price = 40, UserId = 3, Description = "10 numara arsa!", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 18, Title = "30x35 arsa, sahibinden.", Price = 75, UserId = 4, Description = "İstediğini ek, biç.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 19, Title = "Her türlü alet mevcut", Price = 40, UserId = 6, Description = "Kullanıma hazır spor salonu.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 20, Title = "3 kuşaktır işlettiğimiz spor salonu satılık.", Price = 25, UserId = 5, Description = "Ben olsam düşünmeden alırım.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 21, Title = "Hastane satılır mı demeyin, satılır.", Price = 100000, UserId = 3, Description = "Dahiliye dahil.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 22, Title = "Küçük klinik, her türlü hastaya bi bakarsınız.", Price = 165, UserId = 7, Description = "Çok da alet yok ama iş görür.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 23, Title = "İstanbulun gözde semti Bağcılarda 0+0 daire", Price = 270, UserId = 4, Description = "Hiç düşünmeden kirala dayıoğlu. ", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 24, Title = "3+1 fıstık gibi aileye daire.", Price = 375, UserId = 6, Description = "Parası olmayan aramasın lütfen.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 25, Title = "Siyah Atlet", Price = 85, UserId = 7, Description = "Yaz, kış giyilir. Sıcak tutar.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 26, Title = "Slip Don", Price = 185, UserId = 5, Description = "Biraz rahatsız eder ama, ortamlarda en şık sen olursun!", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 27, Title = "Altın Yüzük", Price = 30, UserId = 4, Description = "Al ve teklif et!", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 28, Title = "Gümüş Bileklik", Price = 45, UserId = 3, Description = "Çok şık, çok güzel!", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 29, Title = "Bere", Price = 20, UserId = 2, Description = "Çocuğunuzun kafası sıccacık!", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 30, Title = "Eldiven", Price = 45, UserId = 5, Description = "Bebeniz kar oynasın.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 31, Title = "SoftMicro 360", Price = 50, UserId = 3, Description = "Her işinizi bununla yapın.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 32, Title = "Stopify", Price = 65, UserId = 4, Description = "Müzik dinlemek ister misin?", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 33, Title = "Vergi Ödeme", Price = 400, UserId = 3, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 34, Title = "Fatura Kesme", Price = 500, UserId = 5, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 35, Title = "Hızlı Çözüm", Price = 200, UserId = 6, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 36, Title = "Yedek Malzeme", Price = 300, UserId = 6, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 37, Title = "Matematik", Price = 200, UserId = 5, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 38, Title = "Türkçe", Price = 300, UserId = 3, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 39, Title = "Bina", Price = 1000, UserId = 7, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 40, Title = "Daire", Price = 760, UserId = 3, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 41, Title = "Büyük Otobüs", Price = 5000, UserId = 3, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 42, Title = "Küçük Otobüs", Price = 3000, UserId = 5, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 43, Title = "SUV", Price = 5000, UserId = 7, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 44, Title = "Sedan", Price = 3000, UserId = 4, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 45, Title = "Scooter", Price = 500, UserId = 7, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 46, Title = "Adventure", Price = 350, UserId = 4, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },

					new Advert { Id = 47, Title = "Yelkenli", Price = 10000, UserId = 7, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 48, Title = "Kamaralı ", Price = 15000, UserId = 4, Description = "Lorem Ipsum is simply dummy text of the printing", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 49, Title = "Kedi Tasması", Price = 100, UserId = 3, Description = "Kediniz için şık tasma", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 50, Title = "Kedi Kumu", Price = 120, UserId = 3, Description = "10+2 Kilogram Kedi Kumu", ConditionEnum = AdvertConditionEnum.MinimalUsed },
					new Advert { Id = 51, Title = "Köpek Tasması", Price = 100, UserId = 3, Description = "Köpeğiniz için şık tasma", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 52, Title = "Kuru Köpek Maması", Price = 900, UserId = 4, Description = "10+2 Kilogram Kuru Köpek Maması", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 55, Title = "Balık Maması", Price = 200, UserId = 4, Description = "1 Kilogram Balık Maması", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 56, Title = "Akvaryum", Price = 1500, UserId = 4, Description = "Büyük boy akvaryum", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 53, Title = "Kuş Yemi", Price = 150, UserId = 5, Description = "1 Kilogram Kuş Yemi", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 54, Title = "Kafes", Price = 500, UserId = 5, Description = "Suluk ve dalları olan kuş kafesi", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 57, Title = "Ev Temizliği", Price = 700, UserId = 5, Description = "Detaylı ev temizliği", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 58, Title = "Ofis Temizliği", Price = 2500, UserId = 6, Description = "Detaylı ofis temizliği", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 59, Title = "İç-Dış Yıkama", Price = 300, UserId = 6, Description = "Detaylı İç-Dış Yıkama", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 60, Title = "Oto-Kuaför", Price = 1200, UserId = 6, Description = "Oto-Kuaför Servisi", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 61, Title = "Takım Elbiseler için Kuru Temizleme", Price = 200, UserId = 7, Description = "Takım elbiselerinizi 1 günde tertemiz yapıyoruz.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 62, Title = "Diğer Kuru Temizleme", Price = 50, UserId = 7, Description = "Giyecekleriniz için hızlı kuru temizleme servisi", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 63, Title = "Tabut", Price = 3500, UserId = 7, Description = "İçine girince güzel.", ConditionEnum = AdvertConditionEnum.FactoryNew },
					new Advert { Id = 64, Title = "Cenaze Yemeği", Price = 7500, UserId = 7, Description = "Hayır duası için ...", ConditionEnum = AdvertConditionEnum.FactoryNew }
			);

		}


	}
}

using Biletify.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Concrete.EfCore.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Properties).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired().HasColumnType("real");
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("date('now')");
            builder.Property(p => p.ModifiedDate).HasDefaultValueSql("date('now')");
            builder.ToTable("Products");
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Fenerbahçe-Galatasaray",
                    Price = 1000,
                    Properties = "Dev derbinin futbol maçı bileti",
                    Url = "fb-gs-bilet",
                    ImageUrl = "1.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Cem Yılmaz Diamond Elite Plus",
                    Price = 700,
                    Properties = "Ünlü komedyen Cem Yılmaz Stand-Up",
                    Url = "cem-yilmaz-bilet",
                    ImageUrl = "2.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Sezen Aksu Konseri (Zorlu PSM)",
                    Price = 350,
                    Properties = "Minik kuş Sezen Aksu'nun konser bileti",
                    Url = "sezen-aksu-bilet",
                    ImageUrl = "3.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Ata Demirer Gazinosu",
                    Price = 400,
                    Properties = "Ata Demirer talk show gösterisi",
                    Url = "ata-demirer-bilet",
                    ImageUrl = "4.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 5,
                    Name = "Konuşanlar",
                    Price = 550,
                    Properties = "Dijital dünyanın talk show gösterisi Hasan Can Kaya",
                    Url = "konusanlar-bilet",
                    ImageUrl = "5.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 6,
                    Name = "Mahşer-i Cümbüş Oyunu",
                    Price = 400,
                    Properties = "Türkiye’de modern doğaçlama tiyatronun öncüsü olan Mahşer-i Cümbüş, tiyatroseverler ile buluşmaya devam ediyor",
                    Url = "mahseri-cumbus-bilet",
                    ImageUrl = "6.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 7,
                    Name = "Duman Konseri (Kuruçeşme)",
                    Price = 800,
                    Properties = "Türkçe rock öncü grubu Duman",
                    Url = "duman-bilet",
                    ImageUrl = "7.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 8,
                    Name = "Beekeeper Sinema",
                    Price = 75,
                    Properties = "Ünlü aksiyon oyuncusu Jason Statham'ın son filmi",
                    Url = "beekeper-bilet",
                    ImageUrl = "8.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 9,
                    Name = "Fenerbahçe-Real Madrid",
                    Price = 450,
                    Properties = "Euroleague basketbol heyecanı burada",
                    Url = "fb-rma-bilet",
                    ImageUrl = "9.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 10,
                    Name = "Tomorrowland 2024 (Almanya)",
                    Price = 1800,
                    Properties = "Dünyanın en eğlenceli müzik festivali: Tomorrowland 2024",
                    Url = "tomorrowland-bilet",
                    ImageUrl = "10.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 11,
                    Name = "Örümcek Adam Eve Dönüş Yok Sinema",
                    Price = 75,
                    Properties = "Örümcek adam serisinin son filmi",
                    Url = "orumcek-adam-bilet",
                    ImageUrl = "11.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 12,
                    Name = "Chill-Out Festival Istanbul 2024",
                    Price = 600,
                    Properties = "“Yeryüzündeki Cennet” mottosu ile 18 yılı geride bırakan Chill-Out Festival, 19 Mayıs'ta müzikseverleri Garden Fiesta’da buluşturuyor.",
                    Url = "chill-out-bilet",
                    ImageUrl = "12.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 13,
                    Name = "80’ler 90’lar Gülümseten Hatıralar",
                    Price = 310,
                    Properties = "80’ler ‘90lar Gülümseten Hatıralar sizlerle…",
                    Url = "seksenler-doksanlar-bilet",
                    ImageUrl = "13.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 14,
                    Name = "Beşiktaş-Trabzonspor",
                    Price = 370,
                    Properties = "Kara kartal ve karadeniz fırtınası futbolda karşı karşıya.",
                    Url = "bjk-ts-bilet",
                    ImageUrl = "14.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 15,
                    Name = "Anadolu Efes-Galatasaray",
                    Price = 250,
                    Properties = "Basketbol Türkiye liginde kıyasıya mücadele",
                    Url = "efes-gs-bilet",
                    ImageUrl = "15.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 16,
                    Name = "Şampiyonlar Ligi Finali",
                    Price = 2000,
                    Properties = "Şampiyonlar ligi erken rezervasyon final bileti",
                    Url = "samp-ligi-bilet",
                    ImageUrl = "16.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 17,
                    Name = "Çok Güzel Hareketler 2",
                    Price = 500,
                    Properties = "Yaklaşık 2 yıl boyunca sahne, senaryo ve oyunculuk eğitimlerinden geçen ve 3 sezondur BKM’de kapalı gişe oynayan Çok Güzel Hareketler 2, Eser Yenenler kaptanlığında seyirciyle buluşmaya devam ediyor.",
                    Url = "cghb-2",
                    ImageUrl = "17.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 18,
                    Name = "Açık Mikrofon",
                    Price = 400,
                    Properties = "Eğlence dolu br akşam geçireceğiniz 'Açık Mikrofon Extra' stand up gösterisi sahnede!Yeni hikayeler ve kahkaha dolu anlarla dolu bu gösteri için indirimli stand up biletlerini sakın kaçırmayın...",
                    Url = "acik-mikrofon",
                    ImageUrl = "18.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 19,
                    Name = "LEGOLAND Discovery Centre",
                    Price = 220,
                    Properties = "Dünyaca ünlü çocuk ve aile eğlence merkezi LEGOLAND® Discovery Centre İstanbul, 2-17 yaş arasındaki çocuklar ve yetişkinler için bir arada keyifli vakit geçirip, yaratıcılıklarını geliştirecekleri eğlenceli ve öğretici etkinlikler sunuyor. ",
                    Url = "lego-land",
                    ImageUrl = "19.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 20,
                    Name = "Samara Joy",
                    Price = 650,
                    Properties = "1999 doğumlu sanatçı müzik eğitimini 2021 yılında tamamladı. Aynı yıl kendi adını taşıyan ilk albümü ile JazzTimes tarafından ‘’En İyi Yeni Sanatçı’’ seçildi. Broadway, Inc.'in Porgy ve Bess'in (Summertime) adlı müzik videosunda Women of Color'da yer aldı. ",
                    Url = "samara-joy",
                    ImageUrl = "20.png",
                    IsHome = true
                }
                );
        }
    }
}

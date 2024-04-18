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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.Url).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
            builder.HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Spor",
                        Description = "Spor Müsabakası Biletleri",
                        Url = "spor-biletleri"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Sinema",
                        Description = "Sinema Biletleri",
                        Url = "sinema-biletleri"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Müzik",
                        Description = "Konser Biletleri",
                        Url = "konser-biletleri"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Tiyatro ",
                        Description = "Tiyatro Biletleri",
                        Url = "tiyatro-biletleri"
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Festival",
                        Description = "Festival Biletleri",
                        Url = "festival-biletleri"
                    },
                    new Category
                    {
                        Id = 6,
                        Name = "Talk Show",
                        Description = "Talk Show Biletleri",
                        Url = "talk-show-biletleri"
                    });
        }
    }
}

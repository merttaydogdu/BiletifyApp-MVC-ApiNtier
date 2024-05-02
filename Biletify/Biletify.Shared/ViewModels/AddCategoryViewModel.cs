using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels
{
    public class AddCategoryViewModel
    {
        [JsonPropertyName("Name")]
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} alan boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanına uzunluğu {1} karakterden küçük değer girilemez.")]
        [MaxLength(100, ErrorMessage = "{0} alanına uzunluğu {1} karakterden büyük değer girilemez.")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} alan boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanına uzunluğu {1} karakterden küçük değer girilemez.")]
        [MaxLength(100, ErrorMessage = "{0} alanına uzunluğu {1} karakterden büyük değer girilemez.")]
        public string? Description { get; set; }
        public string? Url { get; set; }
        [JsonPropertyName("IsActive")]
        [DisplayName("Kategori Aktif mi")]
        public bool IsActive { get; set; }
    }
}

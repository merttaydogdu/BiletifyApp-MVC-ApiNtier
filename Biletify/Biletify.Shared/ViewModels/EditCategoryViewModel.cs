using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        [DisplayName("Ürün")]
        public string Name { get; set; }
        [JsonPropertyName("Kategori Açıklaması")]
        [DisplayName("Kategori Açıklaması")]
        public string Description { get; set; }
        [JsonPropertyName("Ürün Url")]
        [DisplayName("Ürün Url")]
        public string Url { get; set; }
        [JsonPropertyName("Ürün Aktifliği")]
        [DisplayName("Ürün Aktifliği")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

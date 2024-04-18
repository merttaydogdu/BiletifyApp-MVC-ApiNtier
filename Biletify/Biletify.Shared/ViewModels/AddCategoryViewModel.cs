using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        [DisplayName("Kategori Açıklaması")]
        public string Description { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("IsActive")]
        [DisplayName("Kategori Aktif mi")]
        public bool IsActive { get; set; }
    }
}

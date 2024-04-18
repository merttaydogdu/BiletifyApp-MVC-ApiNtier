﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        [DisplayName("Ürün")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanına uzunlu�u {1} karakterden küçükk değer girilemez.")]
        [MaxLength(100, ErrorMessage = "{0} alanına uzunluğu {1} karakterden büyükk değer girilemez.")]
        public string Name { get; set; }


        [JsonPropertyName("Properties")]
        [DisplayName("Ürün �zellikleri")]
        public string Properties { get; set; }


        [JsonPropertyName("Price")]
        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public decimal? Price { get; set; }


        [JsonPropertyName("ImageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }


        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [JsonPropertyName("IsActive")]
        [DisplayName("Aktif Ürün")]
        public bool IsActive { get; set; }


        [JsonPropertyName("IsHome")]
        [DisplayName("Ana Sayfa Ürünü")]
        public bool IsHome { get; set; }


        [JsonPropertyName("CategoryIds")]
        public List<int> CategoryIds { get; set; }


        [DisplayName("Kategoriler")]
        public List<CategoryViewModel> Categories { get; set; }

    }
}

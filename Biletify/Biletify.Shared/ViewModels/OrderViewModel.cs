using Biletify.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels
{
    public class OrderViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz.")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string LastName { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Address { get; set; }
        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string City { get; set; }
        [DisplayName("Telefon")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string PhoneNumber { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Geçersiz email adresi")]
        public string Email { get; set; }
        [DisplayName("Not")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Note { get; set; }

        //credit card
        [DisplayName("Kart Sahibi Ad Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string CardName { get; set; }
        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string CardNumber { get; set; }
        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string ExpirationMonth { get; set; }
        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string ExpirationYear { get; set; }
        [DisplayName("Güvenlik Kodu")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Cvc { get; set; }

        public Cart Cart { get; set; }
    }
}

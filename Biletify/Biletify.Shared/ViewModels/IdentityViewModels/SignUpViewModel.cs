using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels.IdentityViewModels
{
    public class SignUpViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string UserName { get; set; }

        [DisplayName("Email Adresiniz")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        public string RePassword { get; set; }
    }
}

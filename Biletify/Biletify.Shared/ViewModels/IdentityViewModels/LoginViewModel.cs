using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels.IdentityViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz")]
        public string UserName { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

    }
}

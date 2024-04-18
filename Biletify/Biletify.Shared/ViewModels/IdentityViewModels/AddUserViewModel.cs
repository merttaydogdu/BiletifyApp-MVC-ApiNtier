using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels.IdentityViewModels
{
    public class AddUserViewModel
    {
        [DisplayName("Ad")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Parola")]
        public string Password { get; set; }

        public List<AssignRolesViewModel> Roles { get; set; }
    }
}

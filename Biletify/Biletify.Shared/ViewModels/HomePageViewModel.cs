using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Shared.ViewModels
{
    public class HomePageViewModel
    {
        public List<ProductViewModel> FeaturedProducts { get; set; }
        public List<ProductViewModel> ProductList { get; set; }
        public List<ProductViewModel> MusicProducts { get; set; }

        public HomePageViewModel()
        {
            ProductList = new List<ProductViewModel>();
        }
    }
}

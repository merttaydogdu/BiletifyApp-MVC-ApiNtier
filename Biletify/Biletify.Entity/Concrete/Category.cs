using Biletify.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Entity.Concrete
{
    public class Category : BaseEntity, IMainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}

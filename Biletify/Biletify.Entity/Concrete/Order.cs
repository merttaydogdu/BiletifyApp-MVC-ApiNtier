using Biletify.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Entity.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderStateType OrderState { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public enum EnumPaymentType
    {
            CreditCard = 0,
            Eft = 1 ,
            Cash = 2
    }

    public enum EnumOrderStateType
    {
        Waiting = 0,
        Unpaid = 1,
        Completed = 2
    }
}

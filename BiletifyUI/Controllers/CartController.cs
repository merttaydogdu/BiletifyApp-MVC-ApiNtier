using Biletify.Business.Abstract;
using Biletify.Entity.Concrete;
using Biletify.Entity.Concrete.Identity;
using Biletify.Shared.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BiletifyUI.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartItemService _cartItemManager;
        private readonly ICartService _cartManager;
        private readonly IOrderService _orderManager;

        public CartController(UserManager<User> userManager, ICartItemService cartItemManager, ICartService cartManager, IOrderService orderManager)
        {
            _userManager = userManager;
            _cartItemManager = cartItemManager;
            _cartManager = cartManager;
            _orderManager = orderManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                Cart cart = await _cartManager.GetCartByUserIdAsync(userId);
                if (cart != null)
                {
                    return View(cart);
                }

            }
            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                await _cartItemManager.AddCartItemToCartAsync(userId, id, quantity);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> ChangeQuantity(int id, int quantity)
        {
            await _cartItemManager.ChangeQuantityAsync(id, quantity > 0 ? quantity : 1);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            await _cartItemManager.DeleteItemFromCartAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartManager.GetCartByUserIdAsync(userId);
            OrderViewModel orderViewModel = new OrderViewModel
            {
                FirstName = "Arda",
                LastName = "Güler",
                Address = "Caferağa Mahallesi, Yıldız Sokak No:55",
                City="İstanbul",
                PhoneNumber = "5554442211",
                Email = "ardaguler@gmail.com",
                Note = "Lütfen zile basmayın ve posta kutusuna bırakabilirsiniz.",
                CardName = "Arda Güler",
                CardNumber = "4603450000000000",
                ExpirationMonth = "7",
                ExpirationYear = "2028",
                Cvc = "354",
            };
            orderViewModel.Cart = cart;
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderViewModel orderViewModel)
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartManager.GetCartByUserIdAsync(userId);
            orderViewModel.Cart = cart;
            if (ModelState.IsValid)
            {
                Options options = new Options();
                options.ApiKey = "sandbox-WILx5adjDkSNZcogZIobjB4H2MaO0m4D";
                options.SecretKey = "sandbox-0OXPay6WTIzPr2LPqGrIagfkVD5fqABT";
                options.BaseUrl = "https://sandbox-api.iyzipay.com";

                CreatePaymentRequest request = new CreatePaymentRequest();
                request.Locale = Locale.TR.ToString();
                request.ConversationId = "1";
                request.Price = cart.TotalPrice().ToString().Replace(",",".");
                request.PaidPrice = cart.TotalPrice().ToString().Replace(",", ".");
                request.Currency = Currency.TRY.ToString();
                request.Installment = 1;
                request.BasketId = cart.Id.ToString();
                request.PaymentChannel = PaymentChannel.WEB.ToString();
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

                PaymentCard paymentCard = new PaymentCard();
                paymentCard.CardHolderName = orderViewModel.CardName;
                paymentCard.CardNumber = orderViewModel.CardNumber;
                paymentCard.ExpireMonth = orderViewModel.ExpirationMonth;
                paymentCard.ExpireYear = orderViewModel.ExpirationYear;
                paymentCard.Cvc = orderViewModel.Cvc;
                paymentCard.RegisterCard = 0;
                request.PaymentCard = paymentCard;

                Buyer buyer = new Buyer();
                buyer.Id = userId;
                buyer.Name = orderViewModel.FirstName;
                buyer.Surname = orderViewModel.LastName;
                buyer.GsmNumber = orderViewModel.PhoneNumber;
                buyer.Email = orderViewModel.Email;
                buyer.IdentityNumber = "74300864791";
                buyer.LastLoginDate = "2023-10-05 12:43:35";
                buyer.RegistrationDate = "2024-04-21 15:12:09";
                buyer.RegistrationAddress = orderViewModel.Address;
                buyer.Ip = "85.34.78.112";
                buyer.City = orderViewModel.City;
                buyer.Country = "Türkiye";
                buyer.ZipCode = "34732";
                request.Buyer = buyer;

                Address shippingAddress = new Address();
                shippingAddress.ContactName = orderViewModel.FirstName;
                shippingAddress.City = orderViewModel.City;
                shippingAddress.Country = "Türkiye";
                shippingAddress.Description = orderViewModel.Address;
                shippingAddress.ZipCode = "34742";
                request.ShippingAddress = shippingAddress;

                Address billingAddress = new Address();
                billingAddress.ContactName = orderViewModel.FirstName;
                billingAddress.City = orderViewModel.City;
                billingAddress.Country = "Türkiye";
                billingAddress.Description = orderViewModel.Address;
                billingAddress.ZipCode = "34742";
                request.BillingAddress = billingAddress;

                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItem basketItem;
                foreach (var item in cart.CartItems)
                {
                    basketItem = new BasketItem();
                    basketItem.Id = item.Id.ToString();
                    basketItem.Name = item.Product.Name;
                    basketItem.Category1 = "General";
                    basketItem.Category2 = "";
                    basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                    basketItem.Price = (item.Quantity*item.Product.Price).ToString().Replace(",", ".");
                    basketItems.Add(basketItem);
                }
                request.BasketItems = basketItems;

                Payment payment = Payment.Create(request, options);
                if (payment.Status == "success")
                {
                    Order order = new Order
                    {
                        OrderNumber = new Random().Next(111111111, 999999999).ToString(),
                        UserId = userId,
                        OrderState = EnumOrderStateType.Waiting,
                        PaymentType = EnumPaymentType.CreditCard,
                        PaymentId = "1",
                        ConversationId = "1",
                        OrderDate = DateTime.Now,
                        FirstName = orderViewModel.FirstName,
                        LastName = orderViewModel.LastName,
                        Address = orderViewModel.Address,
                        City = orderViewModel.City,
                        Email = orderViewModel.Email,
                        PhoneNumber = orderViewModel.PhoneNumber,
                        Note = orderViewModel.Note,
                        OrderDetails = cart.CartItems.Select(ci => new OrderDetail
                        {
                            ProductId = ci.ProductId,
                            Price = ci.Product.Price,
                            Quantity = ci.Quantity
                        }).ToList()
                    };
                    await _orderManager.CreateAsync(order);
                    await _cartItemManager.ClearCartAsync(cart.Id);
                    return Redirect("~/");
                }
                ModelState.AddModelError("", payment.ErrorMessage);
            }
            return View(orderViewModel);
        }
    }
}

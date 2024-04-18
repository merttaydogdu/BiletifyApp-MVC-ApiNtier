using Biletify.Business.Abstract;
using Biletify.Entity.Concrete.Identity;
using Biletify.Shared.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace BiletifyUI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICartService _cartManager;
        private readonly IOrderService _orderManager;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, ICartService cartManager, IOrderService orderManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _cartManager = cartManager;
            _orderManager = orderManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _orderManager.GetAllOrderAsync(userId);
            return View(orders);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı bulunamadı");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Parola hatalı");
                    return View(loginViewModel);
                }
                return Redirect(loginViewModel.ReturnUrl ?? "~/");
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    UserName = signUpViewModel.UserName,
                    Email = signUpViewModel.Email,
                    FirstName = signUpViewModel.FirstName,
                    LastName = signUpViewModel.LastName
                };
                var result = await _userManager.CreateAsync(newUser, signUpViewModel.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Customer");
                    await _cartManager.InitializeCartAsync(newUser.Id);
                    return RedirectToAction("Login");
                }
            }
            return View(signUpViewModel);
        }

    }
}

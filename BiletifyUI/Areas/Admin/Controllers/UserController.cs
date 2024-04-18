using Biletify.Entity.Concrete.Identity;
using Biletify.Shared.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiletifyUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _userManager.Users.ToListAsync();
            List<UserViewModel> userViewModels = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                CreatedDate = (DateTime)u.CreatedDate
            }).ToList();
            return View(userViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles.Select(r => new AssignRolesViewModel
            {
                RoleId = r.Id,
                RoleName = r.Name,
                IsAssigned = userRoles.Any(x => x == r.Name)
            }).ToListAsync();
            UserRolesViewModel userRolesViewModel = new UserRolesViewModel
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                UserName = user.UserName,
                Roles = roles
            };
            return View(userRolesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoles(UserRolesViewModel userRolesViewModel)
        {
            bool IsSelectedRole = userRolesViewModel.Roles.Any(x=>x.IsAssigned == true);
            if (ModelState.IsValid && IsSelectedRole)
            {
                var user = await _userManager.FindByIdAsync(userRolesViewModel.Id);
                foreach (var r in userRolesViewModel.Roles)
                {
                    if (r.IsAssigned)
                        await _userManager.AddToRoleAsync(user, r.RoleName);
                    else
                        await _userManager.RemoveFromRoleAsync(user, r.RoleName);
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "En az bir rol seçmelisiniz.");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var rolesNames = await _roleManager.Roles.Select(r => new AssignRolesViewModel
            {
                RoleId = r.Id,
                RoleName = r.Name,
                IsAssigned = false
            }).ToListAsync();
            AddUserViewModel addUserViewModel = new AddUserViewModel
            {
                Roles = rolesNames
            };
            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = addUserViewModel.FirstName,
                    LastName = addUserViewModel.LastName,
                    Email = addUserViewModel.Email,
                    UserName = addUserViewModel.UserName
                };

                var result = await _userManager.CreateAsync(newUser, "Asd123.");

                if (result.Succeeded)
                {
                    foreach (var r in addUserViewModel.Roles)
                    {
                        if (!string.IsNullOrEmpty(r.RoleName) && r.IsAssigned)
                            await _userManager.AddToRoleAsync(newUser, r.RoleName);
                    }
                    if(addUserViewModel.Roles.Count == 0)
                    {
                        ModelState.AddModelError("", "Lütfen en az bir rol seçiniz.");
                        return View(addUserViewModel);
                    }
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Bir hata oluştu");
            }
            return View(addUserViewModel);
        } 
    }
}


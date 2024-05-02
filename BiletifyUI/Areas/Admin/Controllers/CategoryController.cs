using BiletifyUI.Areas.Admin.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Biletify.Business.Abstract;
using Biletify.Shared.ResponseViewModels;
using Biletify.Shared.ViewModels;
using Biletify.Business.Concrete;
using Biletify.Entity.Concrete;

namespace BiletifyUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;
        

        public CategoryController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(bool id = false)
        {
            Response<List<CategoryViewModel>> result = await _categoryManager.GetNonDeletedCategories(id);
            ViewBag.ShowDeleted = id;
            return View(result.Data);
        }

        

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AddCategoryViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryViewModel addCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addCategoryViewModel);
            }

            var response = await _categoryManager.CreateAsync(addCategoryViewModel);

            if (response.IsSucceeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, response.Error);
                return View(addCategoryViewModel);
            }
        }

        public async Task<IActionResult> UpdateIsActive(EditCategoryViewModel editCategoryViewModel)
        {
            var result = await _categoryManager.UpdateAsync(editCategoryViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _categoryManager.GetByIdAsync(id);

            if (!response.IsSucceeded)
            {
                return NotFound();
            }

            var categoryViewModel = response.Data;
            var editCategoryViewModel = new EditCategoryViewModel
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name,
                Description = categoryViewModel.Description,
                Url = categoryViewModel.Url,
                IsActive = categoryViewModel.IsActive
            };

            return View(editCategoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel editCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editCategoryViewModel);
            }

            var response = await _categoryManager.UpdateAsync(editCategoryViewModel);

            if (!response.IsSucceeded)
            {
                ModelState.AddModelError(string.Empty, response.Error);
                return View(editCategoryViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryManager.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return RedirectToAction("Index");
            }

            var categoryViewModel = response.Data;
            return View(categoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _categoryManager.HardDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

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
        public async Task<IActionResult> Create(AddCategoryViewModel addCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryManager.CreateAsync(addCategoryViewModel);

            if (result.IsSucceeded)
            {
                return RedirectToAction("Details", new { id = result.Data.Id });
            }
            else
            {
                ModelState.AddModelError("", result.Error);
                return View(addCategoryViewModel);
            }
        }

        public async Task<IActionResult> UpdateIsActive(EditCategoryViewModel editCategoryViewModel)
        {
            var result = await _categoryManager.UpdateAsync(editCategoryViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, EditCategoryViewModel editCategoryViewModel)
        {
            if (id != editCategoryViewModel.Id)
            {
                return BadRequest();
            }

            var result = await _categoryManager.UpdateAsync(editCategoryViewModel);

            if (result.IsSucceeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(editCategoryViewModel);
            }
        }
    }
}

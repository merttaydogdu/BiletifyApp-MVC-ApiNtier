using Biletify.Shared.ResponseViewModels;
using Biletify.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Response<CategoryViewModel>> CreateAsync(AddCategoryViewModel addCategoryViewModel);
        Task<Response<CategoryViewModel>> UpdateAsync(EditCategoryViewModel editCategoryViewModel);
        Task<Response<NoContent>> HardDeleteAsync(int id);
        Task<Response<NoContent>> SoftDeleteAsync(int id);
        Task<Response<List<CategoryViewModel>>> GetAllAsync();
        Task<Response<CategoryViewModel>> GetByIdAsync(int id);
        Task<Response<List<CategoryViewModel>>> GetActiveCategories(bool isActive = true);
        Task<Response<List<CategoryViewModel>>> GetNonDeletedCategories(bool isDeleted = false);
        Task<Response<int>> GetActiveCategoryCount();
        Task<Response<int>> GetCategoryCount();

    }
}

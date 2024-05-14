using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MyShop.Domain.Models;
using MyShop.Persistence.Base;
using MyShop.Web.ViewModels.Category;

namespace MyShop.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IMapper mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }

    // GET: CategoryController
    public async Task<IActionResult> Index()
    {
        var categories = await categoryRepository.GetAllCategories();
        var categoryIndexViewModels = this.mapper.Map<List<CategoryIndexViewModel>>(categories);

        return View(categoryIndexViewModels);
    }

    // GET: CategoryController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var category = await this.categoryRepository.GetCategory(id);

        if (category == null)
        {
            return View("_NotFound");
        }

        var categoryDetailsViewModel = this.mapper.Map<CategoryDetailsViewModel>(category);

        return View(categoryDetailsViewModel);
    }

    public async Task<IActionResult> DetailsByName(string name)
    {
        var category = await this.categoryRepository.GetCategory(name);

        if (category == null)
        {
            return View("_NotFound");
        }

        var categoryDetailsViewModel = this.mapper.Map<CategoryDetailsViewModel>(category);

        return View("Details", categoryDetailsViewModel);
    }

    // GET: CategoryController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CategoryController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryCreateViewModel categoryCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(categoryCreateViewModel);
        }

        var category = this.mapper.Map<Category>(categoryCreateViewModel);

        await this.categoryRepository.AddCategory(category);

        return RedirectToAction("Index");
    }

    // GET: CategoryController/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
        var category = await this.categoryRepository.GetCategory(id);
        if (category == null)
        {
            return View("_NotFound");
        }

        var categoryUpdateViewModel = this.mapper.Map<CategoryUpdateViewModel>(category);
        return View(categoryUpdateViewModel);
    }

    // POST: CategoryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CategoryUpdateViewModel categoryUpdateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(categoryUpdateViewModel);
        }

        var category = await this.categoryRepository.GetCategory(categoryUpdateViewModel.Id);
        if (category == null)
        {
            return View("_NotFound");
        }

        category.Name = categoryUpdateViewModel.Name;

        await this.categoryRepository.UpdateCategory(category);

        return RedirectToAction("Index");
    }

    // GET: CategoryController/Delete/5
    public async Task<IActionResult> DeleteConfirmation(Guid id)
    {
        var category = await this.categoryRepository.GetCategory(id);
        if (category == null)
        {
            return View("_NotFound");
        }

        var categoryDeleteViewModel = this.mapper.Map<CategoryDeleteViewModel>(category);
        return View("Delete", categoryDeleteViewModel);
    }

    // POST: CategoryController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {

        var category = await this.categoryRepository.GetCategory(id);
        if (category == null)
        {
            return View("_NotFound");
        }

        await this.categoryRepository.DeleteCategory(category);

        return RedirectToAction("Index");
    }
}
using AutoMapper;

using Microsoft.AspNetCore.Http;
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
    public ActionResult Create()
    {
        return View();
    }

    // POST: CategoryController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CategoryController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CategoryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CategoryController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CategoryController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
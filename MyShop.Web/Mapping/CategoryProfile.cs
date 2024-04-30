using AutoMapper;

using MyShop.Domain.Models;
using MyShop.Web.ViewModels.Category;

namespace MyShop.Web.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        ////CreateMap<CreateCategoryViewModel, Category>();
        ////CreateMap<UpdateCategoryViewModel, Category>();

        CreateMap<Category, CategoryIndexViewModel>();

        CreateMap<Category, CategoryDetailsViewModel>();
    }
}
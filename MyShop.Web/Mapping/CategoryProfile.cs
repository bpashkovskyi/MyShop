using AutoMapper;

using MyShop.Domain.Models;
using MyShop.Web.ViewModels.Category;

namespace MyShop.Web.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCreateViewModel, Category>();
        CreateMap<CategoryUpdateViewModel, Category>().ReverseMap();

        CreateMap<Category, CategoryIndexViewModel>();

        CreateMap<Category, CategoryDetailsViewModel>();

        CreateMap<Category, CategoryDeleteViewModel>();

    }
}
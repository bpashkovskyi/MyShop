////using AutoMapper;

////namespace MyShop.Web.Mapping;

////public class ProductProfile : Profile
////{
////    public ProductProfile()
////    {
////        CreateMap<CreateProductViewModel, Product>();
////        CreateMap<UpdateProductViewModel, Product>();

////        CreateMap<Product, ProductListViewModel>()
////            .ForMember(productListViewModel => productListViewModel.CategoryName, option => option.MapFrom(product => product.Category.Title));

////        CreateMap<Product, ProductDetailsViewModel>()
////            .ForMember(productListViewModel => productListViewModel.CategoryName, option => option.MapFrom(product => product.Category.Title));
////    }
////}
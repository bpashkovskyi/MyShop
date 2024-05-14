using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.ViewModels.Category;

public class CategoryCreateViewModel
{
    [Required]
    public string Name { get; set; }
}
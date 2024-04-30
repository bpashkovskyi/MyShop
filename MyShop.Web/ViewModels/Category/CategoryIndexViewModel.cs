using System.ComponentModel;

namespace MyShop.Web.ViewModels.Category
{
    public class CategoryIndexViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Ім'я категорії")]
        public string Name { get; set; }
    }
}

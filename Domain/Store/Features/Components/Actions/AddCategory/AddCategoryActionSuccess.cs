using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.AddCategory
{
    public record AddCategorySuccessAction
    {
        public AddCategorySuccessAction(Category item) => Item = item;

        public Category Item { get; set; }
    }
}

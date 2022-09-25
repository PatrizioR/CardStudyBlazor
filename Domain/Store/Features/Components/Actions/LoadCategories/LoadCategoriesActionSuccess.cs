using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadCategories
{
    public record LoadCategoriesSuccessAction
    {
        public LoadCategoriesSuccessAction(IEnumerable<Category> items) => Items = items;

        public IEnumerable<Category> Items { get; set; }
    }
}

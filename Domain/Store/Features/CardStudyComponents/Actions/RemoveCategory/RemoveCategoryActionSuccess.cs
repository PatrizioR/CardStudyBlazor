using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveCategory
{
    public record RemoveCategorySuccessAction
    {
        public RemoveCategorySuccessAction(Category item) => Item = item;

        public Category Item { get; set; }
    }
}

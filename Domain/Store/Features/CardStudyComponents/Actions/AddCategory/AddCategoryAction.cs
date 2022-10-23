using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddCategory
{
    public record AddCategoryAction
    {
        public AddCategoryAction(Category item) => Item = item;

        public Category Item { get; set; }
    }
}

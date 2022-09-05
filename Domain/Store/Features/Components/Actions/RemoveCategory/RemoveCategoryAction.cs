using CardStudyBlazor.Domain.Models;
using System;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveCategory
{
    public record RemoveCategoryAction
    {
        public RemoveCategoryAction(Category item) => Item = item;

        public Category Item { get; set; }
    }
}

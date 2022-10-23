using Fluxor;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddCategory;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Linq;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Reducers
{
    public class AddCategoryActionsReducer
    {
        [ReducerMethod(typeof(AddCategoryAction))]
        public static CardStudyComponentsState ReduceAddCategoryAction(CardStudyComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceAddCategorySuccessAction(CardStudyComponentsState state, AddCategorySuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents != null ? state.CurrentComponents with { Categories = state.CurrentComponents.Categories!.Concat(new List<Category>() { action.Item }).ToImmutableArray() } : new Models.CardStudyComponents() { Categories = new List<Category>() { action.Item }.ToImmutableArray() }
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceAddCategoryFailureAction(CardStudyComponentsState state, AddCategoryFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

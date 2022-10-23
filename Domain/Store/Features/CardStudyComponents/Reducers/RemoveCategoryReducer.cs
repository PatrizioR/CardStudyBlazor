using Fluxor;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveCategory;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Linq;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Reducers
{
    public class RemoveCategoryActionsReducer
    {
        [ReducerMethod(typeof(RemoveCategoryAction))]
        public static CardStudyComponentsState ReduceRemoveCategoryAction(CardStudyComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceRemoveCategorySuccessAction(CardStudyComponentsState state, RemoveCategorySuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents with { Categories = state.CurrentComponents.Categories!.Except(new List<Category>() { action.Item }).ToImmutableArray() }
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceRemoveCategoryFailureAction(CardStudyComponentsState state, RemoveCategoryFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

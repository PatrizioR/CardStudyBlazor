using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadCategories;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class LoadCategoriesActionsReducer
    {
        [ReducerMethod(typeof(LoadCategoriesAction))]
        public static ComponentsState ReduceLoadCategoriesAction(ComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static ComponentsState ReduceLoadCategoriesSuccessAction(ComponentsState state, LoadCategoriesSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents with { Categories = (state.CurrentComponents.Categories != null ? state.CurrentComponents.Categories!.Concat(action.Items).ToImmutableArray() : action.Items).ToImmutableArray() }
            };

        [ReducerMethod]
        public static ComponentsState ReduceLoadCategoriesFailureAction(ComponentsState state, LoadCategoriesFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

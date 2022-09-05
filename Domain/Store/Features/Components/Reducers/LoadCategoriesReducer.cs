using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadCategories;
using CardStudyBlazor.Domain.Store.State;

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
                CurrentCategories = action.Items
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

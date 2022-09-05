using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveCategory;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Linq;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class RemoveCategoryActionsReducer
    {
        [ReducerMethod(typeof(RemoveCategoryAction))]
        public static ComponentsState ReduceRemoveCategoryAction(ComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static ComponentsState ReduceRemoveCategorySuccessAction(ComponentsState state, RemoveCategorySuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentCategories = state.CurrentCategories!.Except(new List<Category>() { action.Item })

            };

        [ReducerMethod]
        public static ComponentsState ReduceRemoveCategoryFailureAction(ComponentsState state, RemoveCategoryFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddCategory;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Linq;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class AddCategoryActionsReducer
    {
        [ReducerMethod(typeof(AddCategoryAction))]
        public static ComponentsState ReduceAddCategoryAction(ComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static ComponentsState ReduceAddCategorySuccessAction(ComponentsState state, AddCategorySuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentCategories = state.CurrentCategories!.Concat(new List<Category>() { action.Item })
            };

        [ReducerMethod]
        public static ComponentsState ReduceAddCategoryFailureAction(ComponentsState state, AddCategoryFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

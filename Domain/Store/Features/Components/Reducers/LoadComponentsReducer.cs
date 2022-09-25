using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadComponents;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class LoadComponentsActionsReducer
    {
        [ReducerMethod(typeof(LoadComponentsAction))]
        public static ComponentsState ReduceLoadComponentsAction(ComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static ComponentsState ReduceLoadComponentsSuccessAction(ComponentsState state, LoadComponentsSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = action.Components with { }
            };

        [ReducerMethod]
        public static ComponentsState ReduceLoadComponentsFailureAction(ComponentsState state, LoadComponentsFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

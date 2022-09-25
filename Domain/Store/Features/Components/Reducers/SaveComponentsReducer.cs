using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.SaveComponents;
using CardStudyBlazor.Domain.Store.State;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class SaveComponentsActionsReducer
    {
        [ReducerMethod(typeof(SaveComponentsAction))]
        public static ComponentsState ReduceSaveComponentsAction(ComponentsState state) =>
            state with
        {
            IsLoading = true,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static ComponentsState ReduceSaveComponentsSuccessAction(ComponentsState state, SaveComponentsSuccessAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static ComponentsState ReduceSaveComponentsFailureAction(ComponentsState state, SaveComponentsFailureAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = action.ErrorMessage,
        };
    }
}

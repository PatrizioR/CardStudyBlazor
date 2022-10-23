using Fluxor;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.SaveComponents;
using CardStudyBlazor.Domain.Store.State;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Reducers
{
    public class SaveComponentsActionsReducer
    {
        [ReducerMethod(typeof(SaveComponentsAction))]
        public static CardStudyComponentsState ReduceSaveComponentsAction(CardStudyComponentsState state) =>
            state with
        {
            IsLoading = true,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceSaveComponentsSuccessAction(CardStudyComponentsState state, SaveComponentsSuccessAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceSaveComponentsFailureAction(CardStudyComponentsState state, SaveComponentsFailureAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = action.ErrorMessage,
        };
    }
}

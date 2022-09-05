using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards;
using CardStudyBlazor.Domain.Store.State;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class LoadFlashcardsActionsReducer
    {
        [ReducerMethod(typeof(LoadFlashcardsAction))]
        public static ComponentsState ReduceLoadFlashcardsAction(ComponentsState state) =>
            state with
        {
            IsLoading = true,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static ComponentsState ReduceLoadFlashcardsSuccessAction(ComponentsState state, LoadFlashcardsSuccessAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = null,
            CurrentFlashcards = action.Items
        };

        [ReducerMethod]
        public static ComponentsState ReduceLoadFlashcardsFailureAction(ComponentsState state, LoadFlashcardsFailureAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = action.ErrorMessage,
        };
    }
}

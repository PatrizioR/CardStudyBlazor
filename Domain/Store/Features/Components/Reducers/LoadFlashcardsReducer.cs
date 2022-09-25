using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.LoadFlashcards;
using CardStudyBlazor.Domain.Store.State;
using System.Collections.Immutable;

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
            CurrentComponents = state.CurrentComponents with { Flashcards = action.Items?.ToImmutableArray() }
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

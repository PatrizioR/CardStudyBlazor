using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.RemoveFlashcard;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class RemoveFlashcardActionsReducer
    {
        [ReducerMethod(typeof(RemoveFlashcardAction))]
        public static ComponentsState ReduceRemoveFlashcardAction(ComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static ComponentsState ReduceRemoveFlashcardSuccessAction(ComponentsState state, RemoveFlashcardSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents with { Flashcards = state.CurrentComponents.Flashcards!.Except(new List<Flashcard>() { action.Item }).ToImmutableArray() }
            };

        [ReducerMethod]
        public static ComponentsState ReduceRemoveFlashcardFailureAction(ComponentsState state, RemoveFlashcardFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

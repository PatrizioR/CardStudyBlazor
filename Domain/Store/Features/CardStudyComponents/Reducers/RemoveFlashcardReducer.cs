using Fluxor;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.RemoveFlashcard;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Reducers
{
    public class RemoveFlashcardActionsReducer
    {
        [ReducerMethod(typeof(RemoveFlashcardAction))]
        public static CardStudyComponentsState ReduceRemoveFlashcardAction(CardStudyComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceRemoveFlashcardSuccessAction(CardStudyComponentsState state, RemoveFlashcardSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents with { Flashcards = state.CurrentComponents.Flashcards!.Except(new List<Flashcard>() { action.Item }).ToImmutableArray() }
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceRemoveFlashcardFailureAction(CardStudyComponentsState state, RemoveFlashcardFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

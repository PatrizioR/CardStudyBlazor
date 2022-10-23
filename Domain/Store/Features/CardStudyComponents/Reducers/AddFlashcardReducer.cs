using Fluxor;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.AddFlashcard;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Reducers
{
    public class AddFlashcardActionsReducer
    {
        [ReducerMethod(typeof(AddFlashcardAction))]
        public static CardStudyComponentsState ReduceAddFlashcardAction(CardStudyComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceAddFlashcardSuccessAction(CardStudyComponentsState state, AddFlashcardSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents with { Flashcards = state.CurrentComponents.Flashcards!.Concat(new List<Flashcard>() { action.Item }).ToImmutableArray() }
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceAddFlashcardFailureAction(CardStudyComponentsState state, AddFlashcardFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcard;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class AddFlashcardActionsReducer
    {
        [ReducerMethod(typeof(AddFlashcardAction))]
        public static ComponentsState ReduceAddFlashcardAction(ComponentsState state) =>
            state with
        {
            IsLoading = true,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static ComponentsState ReduceAddFlashcardSuccessAction(ComponentsState state, AddFlashcardSuccessAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = null,
            CurrentFlashcards = state.CurrentFlashcards!.Concat(new List<Flashcard>() { action.Item })
        };

        [ReducerMethod]
        public static ComponentsState ReduceAddFlashcardFailureAction(ComponentsState state, AddFlashcardFailureAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = action.ErrorMessage,
        };
    }
}

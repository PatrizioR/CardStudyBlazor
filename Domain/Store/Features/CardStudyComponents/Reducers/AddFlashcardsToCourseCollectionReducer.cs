using Fluxor;
using CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcardsToCourseCollection;
using CardStudyBlazor.Domain.Store.State;
using System.Collections.Immutable;

namespace CardStudyBlazor.Domain.Store.Features.Components.Reducers
{
    public class AddFlashcardsToCourseCollectionActionsReducer
    {
        [ReducerMethod(typeof(AddFlashcardsToCourseCollectionAction))]
        public static CardStudyComponentsState ReduceAddFlashcardsToCourseCollectionAction(CardStudyComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceAddFlashcardsToCourseCollectionSuccessAction(CardStudyComponentsState state, AddFlashcardsToCourseCollectionSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = state.CurrentComponents! with { CourseCollection = state.CurrentComponents.CourseCollection! with { CourseCards = (state.CurrentComponents.CourseCollection.CourseCards == null ? action.CourseCardsToAdd : state.CurrentComponents.CourseCollection.CourseCards.Concat(action.CourseCardsToAdd)).ToImmutableArray() } }
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceAddFlashcardsToCourseCollectionFailureAction(CardStudyComponentsState state, AddFlashcardsToCourseCollectionFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

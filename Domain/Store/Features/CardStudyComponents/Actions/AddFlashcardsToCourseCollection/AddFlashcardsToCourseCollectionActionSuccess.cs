using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.Components.Actions.AddFlashcardsToCourseCollection
{
    public record AddFlashcardsToCourseCollectionSuccessAction
    {
        public AddFlashcardsToCourseCollectionSuccessAction(IEnumerable<CourseCard> courseCardsToAdd) => CourseCardsToAdd = courseCardsToAdd;
        public IEnumerable<CourseCard> CourseCardsToAdd { get; set; }
    }
}

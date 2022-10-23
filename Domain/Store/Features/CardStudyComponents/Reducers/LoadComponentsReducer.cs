using Fluxor;
using CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Actions.LoadComponents;
using CardStudyBlazor.Domain.Store.State;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Store.Features.CardStudyComponents.Reducers
{
    public class LoadComponentsActionsReducer
    {
        [ReducerMethod(typeof(LoadComponentsAction))]
        public static CardStudyComponentsState ReduceLoadComponentsAction(CardStudyComponentsState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceLoadComponentsSuccessAction(CardStudyComponentsState state, LoadComponentsSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentComponents = action.Components with { }
            };

        [ReducerMethod]
        public static CardStudyComponentsState ReduceLoadComponentsFailureAction(CardStudyComponentsState state, LoadComponentsFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}

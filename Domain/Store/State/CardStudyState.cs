using CardStudyBlazor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.State
{
    public record CardStudyState : RootState
    {
        public CardStudyState(bool isLoading,
            string? currentErrorMessage,
            string? currentSuccessMessage,
            CardStudyDto? currentCardStudy) : base(isLoading, currentErrorMessage, currentSuccessMessage) => (CurrentCardStudy) = (currentCardStudy);

        public CardStudyDto? CurrentCardStudy { get; set; }
    }
}

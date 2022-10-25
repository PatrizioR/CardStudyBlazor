using CardStudyBlazor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.State
{
    public record CardStudyComponentsState : RootState
    {
        public CardStudyComponentsState(bool isLoading,
            string? currentErrorMessage,
            string? currentSuccessMessage,
            CardStudyComponents? currentComponents) : base(isLoading, currentErrorMessage, currentSuccessMessage) => (CurrentComponents) = (currentComponents);

        public CardStudyComponents? CurrentComponents { get; set; }
    }
}

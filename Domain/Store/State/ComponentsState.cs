using CardStudyBlazor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain.Store.State
{
    public record ComponentsState : RootState
    {
        public ComponentsState(bool isLoading,
            string? currentErrorMessage,
            string? currentSuccessMessage,
            Components currentComponents) : base(isLoading, currentErrorMessage, currentSuccessMessage) => (CurrentComponents) = (currentComponents);

        public Components CurrentComponents { get; set; }
    }
}

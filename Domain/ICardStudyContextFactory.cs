using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain
{
    public interface ICardStudyContextFactory
    {
        Task<CardStudyContext> CreateCardStudyContextAsync();
    }
}

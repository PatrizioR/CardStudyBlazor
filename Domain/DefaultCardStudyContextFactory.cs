using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStudyBlazor.Domain
{
    public class DefaultCardStudyContextFactory : ICardStudyContextFactory
    {
        private readonly IDbContextFactory<CardStudyContext> factory;

        public DefaultCardStudyContextFactory(IDbContextFactory<CardStudyContext> factory) =>
            this.factory = factory;

        public async Task<CardStudyContext> CreateCardStudyContextAsync() =>
            await factory.CreateDbContextAsync();
    }
}

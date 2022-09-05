using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardStudyBlazor.Domain.Models;

namespace CardStudyBlazor.Domain.Services
{
    public interface IClientRepository
    {
        public Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client) where T : class;
        public Task<T> AddAsync<T>(HttpClient client, T item) where T : class;
        public Task RemoveAsync<T>(HttpClient client, T item) where T : class;     
    }
}

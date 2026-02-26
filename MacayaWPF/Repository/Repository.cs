using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        public async Task SaveDataAsync(string storedProcedure, object parameters)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Implemented in Framework layer");
        }

        public async Task<IEnumerable<T>> GetDataAsync<T>(string storedProcedure, object? parameters = null)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Implemented in Framework layer");
        }
    }
}

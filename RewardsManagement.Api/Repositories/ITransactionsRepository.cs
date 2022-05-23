using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RewardsManagement.Api.Entities;

namespace RewardsManagement.Api.Repositories
{
      public interface ITransactionsRepository
    {
        Task<Transaction> GetItemAsync(Guid id);
        Task<IEnumerable<Transaction>> GetItemsAsync();

        Task CreateItemAsync(Transaction item);

        Task UpdateItemAsync(Transaction item);

        Task DeleteItemAsync(Guid id);

        Task<IEnumerable<Transaction>> GetTransactionRewardsAsync();

        Task<Transaction> GetTransactionRewardAsync(Guid id);

        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
    }

}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RewardsManagement.Entities;

namespace RewardsManagement.Repositories
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
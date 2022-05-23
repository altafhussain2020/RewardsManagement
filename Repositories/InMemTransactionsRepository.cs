using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RewardsManagement.Entities;
namespace RewardsManagement.Repositories
{
    public class InMemTransactionsRepository : ITransactionsRepository
    {
        private readonly List<Customer> customers = new()
     {
           new Customer{CustomerId=1001,CustomerName="Customer 1"},
           new Customer{CustomerId=1002,CustomerName="Customer 2"},
           new Customer{CustomerId=1003,CustomerName="Customer 3"},
           new Customer{CustomerId=1004,CustomerName="Customer 4"},
           new Customer{CustomerId=1005,CustomerName="Customer 5"},
           new Customer{CustomerId=1006,CustomerName="Customer 6"}
     };

        private readonly List<Transaction> items = new()
     {
            new Transaction{ TransactionId=Guid.NewGuid(),CustomerId=1001, Narrative="Shopping at Amazon", TransactionAmount=120,  TransactionDate=DateTimeOffset.UtcNow },
            new Transaction{ TransactionId=Guid.NewGuid(),CustomerId=1002, Narrative="Shopping at Casco", TransactionAmount=100, TransactionDate=DateTimeOffset.UtcNow },
            new Transaction{ TransactionId=Guid.NewGuid(),CustomerId=1003, Narrative="Shopping at Ikea", TransactionAmount=200, TransactionDate=DateTimeOffset.UtcNow },
            new Transaction{ TransactionId=Guid.NewGuid(),CustomerId=1004, Narrative="Shopping at Amazon", TransactionAmount=180, TransactionDate=DateTimeOffset.UtcNow },

     };
        public async Task<IEnumerable<Transaction>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Transaction> GetItemAsync(Guid id)
        {
            var item= items.Where(item => item.TransactionId == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Transaction item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Transaction item)
        {
            var index= items.FindIndex(existingItem=>existingItem.TransactionId==item.TransactionId);
            items[index]=item;
             await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
             var index= items.FindIndex(existingItem=>existingItem.TransactionId==id);
            items.RemoveAt(index);
             await Task.CompletedTask;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionRewardsAsync()
        {
             return await Task.FromResult(items);
        }

        public async Task<Transaction> GetTransactionRewardAsync(Guid id)
        {
            var item= items.Where(item => item.TransactionId == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await Task.FromResult(customers);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var item= customers.Where(item => item.CustomerId == id).SingleOrDefault();
             return await Task.FromResult(item);
        }
    }
}


       
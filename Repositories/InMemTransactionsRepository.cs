using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Transaction> GetItems()
        {
            return items;
        }
        public Transaction GetItem(Guid id)
        {
            return items.Where(item => item.TransactionId == id).SingleOrDefault();

        }

        public void CreateItem(Transaction item)
        {
            items.Add(item);
        }

        public void UpdateItem(Transaction item)
        {
            var index= items.FindIndex(existingItem=>existingItem.TransactionId==item.TransactionId);
            items[index]=item;
        }

        public void DeleteItem(Guid id)
        {
             var index= items.FindIndex(existingItem=>existingItem.TransactionId==id);
            items.RemoveAt(index);
        }

        public IEnumerable<Transaction> GetTransactionRewards()
        {
             return items;
        }

        public Transaction GetTransactionReward(Guid id)
        {
            return items.Where(item => item.TransactionId == id).SingleOrDefault();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            return customers.Where(item => item.CustomerId == id).SingleOrDefault();
        }
    }
}


       
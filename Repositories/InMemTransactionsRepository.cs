using System;
using System.Collections.Generic;
using System.Linq;
using RewardsManagement.Entities;
namespace RewardsManagement.Repositories
{
    public class InMemTransactionsRepository : ITransactionsRepository
    {
        private readonly List<Transaction> items = new()
     {
            new Transaction{ Id=Guid.NewGuid(), Name="Customer 1", Price=120,  CreatedDate=DateTimeOffset.UtcNow },
            new Transaction{ Id=Guid.NewGuid(), Name="Customer 2", Price=100, CreatedDate=DateTimeOffset.UtcNow },
            new Transaction{ Id=Guid.NewGuid(), Name="Customer 3", Price=200, CreatedDate=DateTimeOffset.UtcNow },
            new Transaction{ Id=Guid.NewGuid(), Name="Customer 4", Price=180, CreatedDate=DateTimeOffset.UtcNow },

     };
        public IEnumerable<Transaction> GetItems()
        {
            return items;
        }
        public Transaction GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();

        }

        public void CreateItem(Transaction item)
        {
            items.Add(item);
        }

        public void UpdateItem(Transaction item)
        {
            var index= items.FindIndex(existingItem=>existingItem.Id==item.Id);
            items[index]=item;
        }

        public void DeleteItem(Guid id)
        {
             var index= items.FindIndex(existingItem=>existingItem.Id==id);
            items.RemoveAt(index);
        }

        public IEnumerable<Transaction> GetTransactionRewards()
        {
             return items;
        }

        public Transaction GetTransactionReward(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}


       
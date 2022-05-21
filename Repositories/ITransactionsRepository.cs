using System;
using System.Collections.Generic;
using RewardsManagement.Entities;

namespace RewardsManagement.Repositories
{
      public interface ITransactionsRepository
    {
        Transaction GetItem(Guid id);
        IEnumerable<Transaction> GetItems();

        void CreateItem(Transaction item);

        void UpdateItem(Transaction item);

        void DeleteItem(Guid id);
    }

}
using System;
namespace RewardsManagement.Api.Entities
{
    public record CustomerRewards
    {
        public int CustomerId { get; init; }
        public string CustomerName { get; init; }
        public decimal TotalTransactionAmount { get; init; }
        public decimal TotalRewardPoints { get; init; }
    }

}
using System;
namespace RewardsManagement.Entities
{
    public record TransactionReward
    {
        public Guid TransactionId { get; init; }

        public int CustomerId { get; set; }
        public string Narrative { get; init; }
        public decimal TransactionAmount { get; set; }

        public decimal RewardPoints { get; set; }   
        public DateTimeOffset TransactionDate { get; init; }
    }

}
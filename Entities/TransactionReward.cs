using System;
namespace RewardsManagement.Entities
{
    public record TransactionReward
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; set; }

        public decimal RewardPoints { get; set; }   
        public DateTimeOffset CreatedDate { get; init; }
    }

}
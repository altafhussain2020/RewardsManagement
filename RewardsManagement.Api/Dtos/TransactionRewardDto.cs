using System;
namespace RewardsManagement.Api.Dtos
{
    public record TransactionRewardDto
    {
        public Guid TransactionId { get; set; }
        public int CustomerId { get; set; }
        public string Narrative { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal RewardPoints { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }

}
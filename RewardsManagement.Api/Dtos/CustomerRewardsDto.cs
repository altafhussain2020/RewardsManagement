using System;
namespace RewardsManagement.Api.Dtos
{
    public record CustomerRewardsDto
    {
        public int CustomerId { get; init; }
        public string CustomerName { get; init; }
        public decimal TotalTransactionAmount { get; init; }
        public decimal TotalRewardPoints { get; init; }
    }

}
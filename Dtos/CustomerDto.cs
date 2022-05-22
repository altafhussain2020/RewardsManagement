using System;
namespace RewardsManagement.Dtos
{
    public record CustomerDto
    {
        public int CustomerId { get; init; }
        public string CustomerName { get; init; }
    }

}
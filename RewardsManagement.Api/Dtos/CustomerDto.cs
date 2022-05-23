using System;
namespace RewardsManagement.Api.Dtos
{
    public record CustomerDto
    {
        public int CustomerId { get; init; }
        public string CustomerName { get; init; }
    }

}
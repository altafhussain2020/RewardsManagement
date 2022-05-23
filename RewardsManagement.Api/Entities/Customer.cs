using System;
namespace RewardsManagement.Api.Entities
{
    public record Customer
    {
        public int CustomerId { get; init; }        
        public string CustomerName { get; init; }

    }

}
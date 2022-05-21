using System;
namespace RewardsManagement.Entities
{
    public record Transaction
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }

}
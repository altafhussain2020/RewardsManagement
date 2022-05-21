using System;

namespace RewardsManagement.Dtos
{
    public record TransactionDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }


}
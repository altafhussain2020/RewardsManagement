using System;
namespace RewardsManagement.Api.Entities
{
    public record TransactionDto
    {
        public Guid TransactionId { get; init; }
         public int CustomerId { get; set; }
        public string Narrative { get; init; }
        public decimal TransactionAmount { get; set; }        
        public DateTimeOffset TransactionDate { get; init; }
    }

}
using System;
using System.ComponentModel.DataAnnotations;

namespace RewardsManagement.Api.Dtos
{
    public record DeleteTransactionDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string Narrative { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal TransactionAmount { get; init; }

        public decimal RewardPoints { get; }
    }


}
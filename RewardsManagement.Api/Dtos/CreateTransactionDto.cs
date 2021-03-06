using System;
using System.ComponentModel.DataAnnotations;

namespace RewardsManagement.Api.Dtos
{
    public record CreateTransactionDto
    { 
        [Required]
        public int CustomerId { get; init; }
        [Required]
        public string Narrative { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal TransactionAmount { get; init; }

         public decimal RewardPoints { get; init;}

    }


}
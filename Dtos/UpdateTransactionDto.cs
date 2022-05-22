using System;
using System.ComponentModel.DataAnnotations;

namespace RewardsManagement.Dtos
{
    public record UpdateTransactionDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string Narrative { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal TransactionAmount { get; init; }

    }


}
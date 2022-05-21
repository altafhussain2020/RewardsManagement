using System;
using System.ComponentModel.DataAnnotations;

namespace RewardsManagement.Dtos
{
    public record DeleteTransactionDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }

    }


}
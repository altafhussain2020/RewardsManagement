using System;
using System.ComponentModel.DataAnnotations;

namespace RewardsManagement.Dtos
{
    public record UpdateTransactionDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }

    }


}
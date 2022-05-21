using System;
namespace RewardsManagement.Dtos
{
    public record TransactionRewardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  

         public decimal RewardPoints { get; set; }       
        public DateTimeOffset CreatedDate { get; set; }
    }

}
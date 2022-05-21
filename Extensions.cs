using RewardsManagement.Dtos;
using RewardsManagement.Entities;

namespace RewardsManagement
{
    public static class Extensions
    {
        public static TransactionDto AsDto(this Transaction item)
        {
            return new TransactionDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }

         public static TransactionRewardDto AsRewardDto(this Transaction item)
        {
            return new TransactionRewardDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,               
                CreatedDate = item.CreatedDate
            };
        }
    }
}
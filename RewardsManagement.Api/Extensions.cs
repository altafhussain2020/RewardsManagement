using RewardsManagement.Api.Dtos;
using RewardsManagement.Api.Entities;

namespace RewardsManagement.Api
{
    public static class Extensions
    {
        public static TransactionDto AsDto(this Transaction item)
        {
            return new TransactionDto
            {
                TransactionId = item.TransactionId,
                CustomerId = item.CustomerId,
                Narrative = item.Narrative,
                TransactionAmount = item.TransactionAmount,
                TransactionDate = item.TransactionDate
            };
        }

         public static TransactionRewardDto AsRewardDto(this Transaction item,decimal rewardPoints)
        {
            return new TransactionRewardDto
            {
                TransactionId = item.TransactionId,
                CustomerId = item.CustomerId,
                Narrative = item.Narrative,
                TransactionAmount = item.TransactionAmount,               
                TransactionDate = item.TransactionDate,
                RewardPoints=rewardPoints
                
            };
        }


        public static CustomerDto AsCustomerDto(this Customer item)
        {
            return new CustomerDto
            {
                CustomerId = item.CustomerId,
                CustomerName = item.CustomerName,
               
            };
        }

         public static CustomerRewardsDto AsCustomerRewardDto(this CustomerRewards item)
        {
            return new CustomerRewardsDto
            {
                CustomerId = item.CustomerId,
                CustomerName = item.CustomerName,
               TotalRewardPoints=item.TotalRewardPoints,
               TotalTransactionAmount=item.TotalTransactionAmount
            };
        }
    }
}
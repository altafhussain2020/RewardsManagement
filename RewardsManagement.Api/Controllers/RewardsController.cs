using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RewardsManagement.Api.Dtos;
using RewardsManagement.Api.Repositories;
using RewardsManagement.Api.Models;
using System.Threading.Tasks;

namespace RewardsManagement.Api.Controllers
{

    [ApiController]
    [Route("rewards")]
    public class RewardsController : ControllerBase
    {
        RewardEngine oCalc = new RewardEngine();
        const decimal Over50 = 50;
        const decimal Over100 = 100;
        private readonly ITransactionsRepository repository;

        public RewardsController(ITransactionsRepository repository)
        {
            this.repository = repository;

        }
        //Get //transactionRewards
        [HttpGet]
        public async Task<IEnumerable<TransactionRewardDto>> GetTransactionRewardsAsync()
        {
            var items = (await repository.GetTransactionRewardsAsync()).Select(item => item.AsRewardDto(0));
            List<TransactionRewardDto> FinalList = new List<TransactionRewardDto>();
            try
            {
                foreach (var item in items)
                {
                    item.RewardPoints = oCalc.TotalRewards(oCalc.CalculateRewards(item.TransactionAmount, Over50), oCalc.CalculateRewards(item.TransactionAmount, Over100));
                    FinalList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogMessage(ex.Message);
            }
            return await Task.FromResult(FinalList);
        }

        //Get //transactionRewards/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionRewardDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemReward = item.AsRewardDto(0);
            itemReward.RewardPoints = oCalc.TotalRewards(oCalc.CalculateRewards(itemReward.TransactionAmount, Over50), oCalc.CalculateRewards(itemReward.TransactionAmount, Over100));

            return await Task.FromResult(item.AsRewardDto(itemReward.RewardPoints));

        }
      
    }
}
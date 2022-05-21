using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RewardsManagement.Dtos;
using RewardsManagement.Repositories;
using RewardsManagement.Models;

namespace RewardsManagement.Controllers
{

    [ApiController]
    [Route("rewards")]
    public class RewardsController : ControllerBase
    {
        Calc oCalc = new Calc();
        const decimal Over50= 50;
        const decimal Over100= 100;
        private readonly ITransactionsRepository repository;

        public RewardsController(ITransactionsRepository repository)
        {
            this.repository = repository;

        }
        //Get //transactionRewards
        [HttpGet]
        public IEnumerable<TransactionRewardDto> GetTransactionRewards()
        {
            var items = repository.GetTransactionRewards().Select(item => item.AsRewardDto());
             List<TransactionRewardDto> FinalList = new List<TransactionRewardDto>();
            foreach (var item in items)
            {
                item.RewardPoints=oCalc.TotalRewards(oCalc.CalculateRewards(item.Price,Over50),oCalc.CalculateRewards(item.Price,Over100));
                FinalList.Add(item);
            }
            return FinalList;
        }

        //Get //transactionRewards/{id}
        [HttpGet("{id}")]
        public ActionResult<TransactionRewardDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemReward =item.AsRewardDto();             
                itemReward.RewardPoints=oCalc.TotalRewards(oCalc.CalculateRewards(itemReward.Price,50),oCalc.CalculateRewards(itemReward.Price,100));
         
            return item.AsRewardDto();

        }

    }
}
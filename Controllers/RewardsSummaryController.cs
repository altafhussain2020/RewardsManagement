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
    [Route("summary")]
    public class RewardsSummaryController : ControllerBase
    {
        RewardEngine oCalc = new RewardEngine();
        const decimal Over50 = 50;
        const decimal Over100 = 100;
        private readonly ITransactionsRepository repository;

        public RewardsSummaryController(ITransactionsRepository repository)
        {
            this.repository = repository;

        }
        
        //Get //customersummary
          [HttpGet("{months}")]
        public object GetCustomerSummary(int months)
        {
            var items = repository.GetTransactionRewards().Select(item => item.AsRewardDto(0));
            var customers = repository.GetCustomers();
            List<TransactionRewardDto> transactionRewardsList = new List<TransactionRewardDto>();
            List<CustomerRewardsDto> customerRewardsList = new List<CustomerRewardsDto>();
            try
            {
                var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, months);
                bool CurrentMonth = true; if (CurrentMonth) { date = date.AddMonths(0); }
                foreach (var item in items)
                {
                    item.RewardPoints = oCalc.TotalRewards(oCalc.CalculateRewards(item.TransactionAmount, Over50), oCalc.CalculateRewards(item.TransactionAmount, Over100));
                    transactionRewardsList.Add(item);
                }
                var customerRewardTransactions = customers.Where(c => transactionRewardsList.Any(t => t.CustomerId == c.CustomerId)).Select(c => new
                {
                    c.CustomerId,
                    c.CustomerName,
                    TotalTransactionAmount = transactionRewardsList.Where(t => t.CustomerId==c.CustomerId && t.TransactionDate >= date ).Select(t => t.TransactionAmount).Sum(),
                    TotalRewardPoints = transactionRewardsList.Where(t => t.CustomerId.Equals(c.CustomerId) && t.TransactionDate >= date ).Select(t => t.RewardPoints).Sum()
                }).ToList();                             
                
                return customerRewardTransactions;
            }
            catch (Exception ex)
            {
                Logger.LogMessage(ex.Message);
            }
            return null;
        }
    }
}
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RewardsManagement.Api.Controllers;
using RewardsManagement.Api.Dtos;
using RewardsManagement.Api.Entities;
using RewardsManagement.Api.Repositories;
using Xunit;

namespace RewardsManagement.UnitTests
{
    public class RewardsControllerTests
    {
        private readonly Mock<ITransactionsRepository> repositoryStub = new();       
        private readonly Random random = new();
     

        [Fact]
        public async Task GetTransactionRewardsAsync_WithExistsRewardTransactions_ReturnsAllRewardTransactions()
        {
            //Arrange               
            var expectedTransactionsRewards = new[] { CreateRandomReward(), CreateRandomReward(), CreateRandomReward() };

            repositoryStub.Setup(repo => repo.GetTransactionRewardsAsync())
            .ReturnsAsync(expectedTransactionsRewards);

            var controller = new RewardsController(repositoryStub.Object);

            //Act
            var resultItems = await controller.GetTransactionRewardsAsync();

            //Assert
            resultItems.Should().BeEquivalentTo(expectedTransactionsRewards,
            options => options.ComparingByMembers<Transaction>());
        }

       
        private Transaction CreateRandomReward()
        {
            return new()
            {
                TransactionId = Guid.NewGuid(),
                Narrative = Guid.NewGuid().ToString(),
                CustomerId = random.Next(1000),
                TransactionAmount = random.Next(1000),
                TransactionDate = DateTimeOffset.UtcNow

            };
        }
    }
}

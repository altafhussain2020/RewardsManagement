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
    public class TransactionsControllerTests
    {
        private readonly Mock<ITransactionsRepository> repositoryStub = new();
        private readonly Mock<ILogger<TransactionsController>> loggerStub = new();
        private readonly Random random = new();
        [Fact]
        public async Task GetItemAsync_WithNotExistsTransaction_ReturnsNotFound()
        {
            //Arrange               
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Transaction)null);

            var controller = new TransactionsController(repositoryStub.Object, loggerStub.Object);
            //Act

            var result = await controller.GetItemAsync(Guid.NewGuid());

            //Assert
            //Assert.IsType<NotFoundResult>(result.Result);
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetItemAsync_WithExistsTransaction_ReturnsExpectedTransaction()
        {
            //Arrange               
            var expectedTransaction = CreateRandomItem();

            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
             .ReturnsAsync(expectedTransaction);

            var controller = new TransactionsController(repositoryStub.Object, loggerStub.Object);
            //Act

            var result = await controller.GetItemAsync(Guid.NewGuid());


            //Assert
            result.Value.Should().BeEquivalentTo(expectedTransaction,
            options => options.ComparingByMembers<Transaction>());
           
        }

        [Fact]
        public async Task GetItemsAsync_WithExistsTransactions_ReturnsAllTransactions()
        {
            //Arrange               
            var expectedTransactions = new[] { CreateRandomItem(), CreateRandomItem(), CreateRandomItem() };

            repositoryStub.Setup(repo => repo.GetItemsAsync())
            .ReturnsAsync(expectedTransactions);

            var controller = new TransactionsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var resultItems = await controller.GetItemsAsync();

            //Assert
            resultItems.Should().BeEquivalentTo(expectedTransactions,
            options => options.ComparingByMembers<Transaction>());
        }

        [Fact]
        public async Task CreateItemAsync_WithTransactionToCreate_ReturnsCreatedTransaction()
        {
            //Arrange               
            var newTransaction = new CreateTransactionDto()
            {
                //TransactionId = Guid.NewGuid(),
                Narrative = Guid.NewGuid().ToString(),
                CustomerId = random.Next(1000),
                TransactionAmount = random.Next(100),
                RewardPoints = random.Next(1000)
            };


            var controller = new TransactionsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var resultItems = await controller.CreateItemAsync(newTransaction);


            //Assert
            var createdTransaction = (resultItems.Result as CreatedAtActionResult).Value as TransactionDto;

            newTransaction.Should().BeEquivalentTo(createdTransaction,
                options => options.ComparingByMembers<TransactionDto>().ExcludingMissingMembers()
            );

            createdTransaction.Narrative.Should().NotBeEmpty();
            createdTransaction.TransactionAmount.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task UpdateItemAsync_WithExistingTransaction_ReturnsNoContent()
        {
            //Arrange 
            var existingTransaction = CreateRandomItem();

            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
             .ReturnsAsync(existingTransaction);

            var transacionId = existingTransaction.TransactionId;

            var transacitonToUpdate = new UpdateTransactionDto()
            {
                Narrative = Guid.NewGuid().ToString(),
                TransactionAmount = random.Next(100)
            };
            var controller = new TransactionsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.UpdateItemAsync(transacionId, transacitonToUpdate);

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }

         [Fact]
        public async Task DeleteItemAsync_WithExistingTransaction_ReturnsNoContent()
        {
            //Arrange 
            var existingTransaction = CreateRandomItem();

            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
             .ReturnsAsync(existingTransaction);

            
            var controller = new TransactionsController(repositoryStub.Object, loggerStub.Object);

            //Act
            var result = await controller.DeleteItemAsync(existingTransaction.TransactionId);

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }
        private Transaction CreateRandomItem()
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

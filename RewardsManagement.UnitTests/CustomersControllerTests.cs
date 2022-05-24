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
    public class CustomersControllerTests
    {
        private readonly Mock<ITransactionsRepository> repositoryStub = new();        
        private readonly Random random = new();
        [Fact]
        public async Task GetCustomerAsync_WithNotExistsCustomer_ReturnsNotFound()
        {
            //Arrange               
            repositoryStub.Setup(repo => repo.GetCustomerAsync(It.IsAny<int>()))
            .ReturnsAsync((Customer)null);

            var controller = new CustomersController(repositoryStub.Object);
            //Act

            var result = await controller.GetCustomerAsync(random.Next(1,100));

            //Assert            
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetItemAsync_WithExistsTransaction_ReturnsExpectedTransaction()
        {
            //Arrange               
            var expectedCustomer = CreateRandomCustomer();

            repositoryStub.Setup(repo => repo.GetCustomerAsync(It.IsAny<int>()))
             .ReturnsAsync(expectedCustomer);

            var controller = new CustomersController(repositoryStub.Object);
            //Act

            var result = await controller.GetCustomerAsync(random.Next(1,100));


            //Assert
            result.Value.Should().BeEquivalentTo(expectedCustomer,
            options => options.ComparingByMembers<Customer>());
           
        }

        [Fact]
        public async Task GetCustomersAsync_WithExistsCustomers_ReturnsAllCustomers()
        {
            //Arrange               
            var expectedCustomers = new[] { CreateRandomCustomer(), CreateRandomCustomer(), CreateRandomCustomer() };

            repositoryStub.Setup(repo => repo.GetCustomersAsync())
            .ReturnsAsync(expectedCustomers);

            var controller = new CustomersController(repositoryStub.Object);

            //Act
            var resultItems = await controller.GetCustomersAsync();

            //Assert
            resultItems.Should().BeEquivalentTo(expectedCustomers,
            options => options.ComparingByMembers<Customer>());
        }

       
        private Customer CreateRandomCustomer()
        {
            return new()
            {
               CustomerId = random.Next(1000),
                CustomerName = Guid.NewGuid().ToString()

            };
        }
    }
}

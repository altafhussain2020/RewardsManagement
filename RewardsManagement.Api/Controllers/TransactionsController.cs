using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RewardsManagement.Api.Entities;
using RewardsManagement.Api.Dtos;
using RewardsManagement.Api.Repositories;
using RewardsManagement.Api.Models;
using System.Threading.Tasks;

namespace RewardsManagement.Api.Controllers
{

    [ApiController]
    [Route("items")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository repository;

        public TransactionsController(ITransactionsRepository repository)
        {
            this.repository = repository;

        }
        //Get //transactions
        [HttpGet]
        public async Task<IEnumerable<TransactionDto>> GetItemsAsync()
        {
            try
            {
                var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
                return items;
            }
            catch (Exception ex)
            {
                throw new ExceptionHandler(ex.Message);
            }

        }

        //Get //transactions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item == null)
            {

                return NotFound();
            }
            return item.AsDto();

        }

        //POST /transaction
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> CreateItemAsync(CreateTransactionDto itemDto)
        {
            Transaction item = new()
            {
                TransactionId = Guid.NewGuid(),
                CustomerId=itemDto.CustomerId,
                Narrative = itemDto.Narrative,
                TransactionAmount = itemDto.TransactionAmount,
                TransactionDate = DateTimeOffset.UtcNow

            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.TransactionId }, item.AsDto());
        }
        //PUT /transaction/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateTransactionDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Transaction updatedItem = existingItem with
            {
                Narrative = itemDto.Narrative,
                 CustomerId = itemDto.CustomerId,
                TransactionAmount = itemDto.TransactionAmount
            };
            if(updatedItem is not null)
            {
                await repository.UpdateItemAsync(updatedItem);
            }
            return NoContent();
        }

        //DELETE / transaction/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
           
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
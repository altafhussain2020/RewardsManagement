using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RewardsManagement.Entities;
using RewardsManagement.Dtos;
using RewardsManagement.Repositories;
using RewardsManagement.Models;

namespace RewardsManagement.Controllers
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
        public IEnumerable<TransactionDto> GetItems()
        {
            try
            {
                var items = repository.GetItems().Select(item => item.AsDto());
                return items;
            }
            catch (Exception ex)
            {
                throw new ExceptionHandler(ex.Message);
            }

        }

        //Get //transactions/{id}
        [HttpGet("{id}")]
        public ActionResult<TransactionDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item == null)
            {

                return NotFound();
            }
            return item.AsDto();

        }

        //POST /transaction
        [HttpPost]
        public ActionResult<TransactionDto> CreateItem(CreateTransactionDto itemDto)
        {
            Transaction item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
        //PUT /transaction/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateTransactionDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Transaction updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            if(updatedItem is not null)
            {
                repository.UpdateItem(updatedItem);
            }
            return NoContent();
        }

        //DELETE / transaction/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
           
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);

            return NoContent();
        }
    }
}
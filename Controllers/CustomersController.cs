using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RewardsManagement.Entities;
using RewardsManagement.Dtos;
using RewardsManagement.Repositories;
using RewardsManagement.Models;
using System.Threading.Tasks;

namespace RewardsManagement.Controllers
{

    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ITransactionsRepository repository;

        public CustomersController(ITransactionsRepository repository)
        {
            this.repository = repository;

        }
        //Get //customers
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            try
            {
                var items = (await repository.GetCustomersAsync()).Select(item => item.AsCustomerDto());
                return items;

               
            }
            catch (Exception ex)
            {
                throw new ExceptionHandler(ex.Message);
            }

        }

        //Get //customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(int id)
        {
            var item = await repository.GetCustomerAsync(id);
            if (item == null)
            {

                return NotFound();
            }
            return item.AsCustomerDto();

        }

       
        
    }
}
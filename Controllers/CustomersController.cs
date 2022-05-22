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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            try
            {
                var items = repository.GetCustomers().Select(item => item.AsCustomerDto());
                return items;
            }
            catch (Exception ex)
            {
                throw new ExceptionHandler(ex.Message);
            }

        }

        //Get //customers/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var item = repository.GetCustomer(id);
            if (item == null)
            {

                return NotFound();
            }
            return item.AsCustomerDto();

        }

       
        
    }
}
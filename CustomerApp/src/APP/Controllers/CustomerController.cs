using System.Collections.Generic;
using System.Linq;
using CustomerApp.BLL;
using CustomerApp.Entities;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            BoCustomer boCustomer = new BoCustomer();
            return Ok(boCustomer.All());
        }

        [HttpGet("{cpf}")]
        public IActionResult Get(string cpf)
        {
            BoCustomer boCustomer = new BoCustomer();
            return Ok(boCustomer.GetByCPF(cpf));
        }
        
        [HttpPost]
        public IActionResult Store(CustomerViewModel model)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            Customer customer = ModelDtoCustomer(model);

            BoCustomer boCustomer = new BoCustomer();
            Customer CreatedCustomer = boCustomer.New(customer);

            if(boCustomer.error.Count > 0){
                foreach (KeyValuePair<string, string> erro in boCustomer.error)
                    ModelState.AddModelError(erro.Key, erro.Value);
                
                return BadRequest(ModelState);
            }
            
            return Ok(CreatedCustomer);
        }

        [HttpPut]
        public IActionResult Update(UpdateCustomerViewModel model)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            Customer customer = ModelDtoCustomer(model);

            BoCustomer boCustomer = new BoCustomer();
            boCustomer.Update(customer);

            if(boCustomer.error.Count > 0){
                foreach (KeyValuePair<string, string> erro in boCustomer.error)
                    ModelState.AddModelError(erro.Key, erro.Value);
                
                return BadRequest(ModelState);
            }
            
            return Ok(customer);
        }

        [HttpDelete("{cpf}")]
        public IActionResult Delete(string cpf)
        {
            new BoCustomer().RemoveCustomer(cpf);

            return NoContent();
        }

        private Customer ModelDtoCustomer(CustomerViewModel model)
        {  
            Customer customer = new Customer(){
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                CPF =  model.CPF
            };

            if(model is UpdateCustomerViewModel) {
                UpdateCustomerViewModel modelUpdate = model as UpdateCustomerViewModel;
                customer.Id = modelUpdate.Id;
            }

            return customer;
        }
    }
}

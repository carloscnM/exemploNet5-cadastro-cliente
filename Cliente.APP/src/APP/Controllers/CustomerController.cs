using System.Collections.Generic;
using System.Linq;
using Cliente.APP.BLL;
using Cliente.APP.Entities;
using Cliente.APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.APP.Controllers
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
        
        [HttpPost]
        public IActionResult Store(CustomerViewModel model)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            Customer customer = new Customer(){
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                CPF = model.CPF
            };

            BoCustomer boCustomer = new BoCustomer();
            boCustomer.New(customer);

            if(boCustomer.error.Count > 0){
                foreach (KeyValuePair<string, string> erro in boCustomer.error)
                    ModelState.AddModelError(erro.Key, erro.Value);
                
                return BadRequest(ModelState);
            }
            
            return Ok(customer);
        }
    }
}

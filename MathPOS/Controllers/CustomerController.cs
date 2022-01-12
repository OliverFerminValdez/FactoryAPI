using FactoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private List<Customer> Customers = new List<Customer>();

        public CustomerController()
        {
            for (int i = 0; i < 5; i++)
            {
                Customer c = new Customer()
                {
                    Customer_Id = i + 1,
                    Name = "Customer " + (i+1),
                    Code = "000" + (i + 1),
                    Address = "Address " + (i + 1),
                    Email = "Customer" + (i + 1) + "@gmail.com",
                    Phone = "000000000" + (i + 1)
                };
                Customers.Add(c);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            if (Customers.Count > 0)
                return Customers;
            else
                return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<Customer>Get(int id)
        {
            if (Customers.Any(c => c.Customer_Id == id))
                return Customers.FirstOrDefault(p => p.Customer_Id == id);
            else
                return NoContent();
        }
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            if (!(Customers.Any(c => c.Customer_Id == customer.Customer_Id)))
                Customers.Add(customer);

            if (Customers.Any(c => c.Customer_Id == customer.Customer_Id))
                return StatusCode(201);
            else
                return NoContent();
        }
        [HttpPut]
        public ActionResult<IEnumerable<Customer>> Put(Customer customer)
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Customer_Id == customer.Customer_Id)
                {
                    Customers[i] = customer;
                    return StatusCode(201);
                }
            }

            return NoContent();
        }
        [HttpDelete]
        public ActionResult<IEnumerable<Product>> Delete(int id)
        {
            var item = Customers.FirstOrDefault(c => c.Customer_Id == id);
            Customers.Remove(item);

            if (!(Customers.Exists(c => c.Customer_Id == id)))
                return StatusCode(200);
            else
                return NoContent();

        }
    }
}

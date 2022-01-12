using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryAPI.Controllers
{
#pragma warning disable CS8604 // Posible argumento de referencia nulo
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private List<Product> Products = new List<Product>();

        public ProductController()
        {
            for (int i = 0; i < 5; i++)
            {
                Product p = new Product()
                {
                    Product_Id = i + 1,
                    Code = "000" + (i + 1),
                    Description = "Description of product " + (i + 1),
                    Name = "Product " + (i + 1),
                    Stock = 1,
                    ExpirationDate = DateTime.Today.AddDays(15),
                    UnitPrice = 500 + 1
                };
                Products.Add(p);
            }
        }
        // GET: ProductController
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            if (Products.Count > 0)
                return Products;
            else
                return NoContent();
        }
        // GET {id}
        [HttpGet("{id}")]
        public ActionResult<Product>Get(int id)
        {
            if (Products.Any(p => p.Product_Id == id))
                return Products.FirstOrDefault(p => p.Product_Id == id);
            else
                return NoContent();

        }
        //POST
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if(!(Products.Any(p => p.Product_Id == product.Product_Id)))
                Products.Add(product);

            if (Products.Any(p => p.Product_Id == product.Product_Id))
                return StatusCode(201);
            else
                return NoContent();
        }
        //PUT
        [HttpPut]
        public ActionResult<IEnumerable<Product>> Put(Product product)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if(Products[i].Product_Id == product.Product_Id)
                {
                    Products[i] = product;
                    return StatusCode(201);
                }
            }
            
            return NoContent();
        }
        //DELETE
        [HttpDelete]
        public ActionResult<IEnumerable<Product>> Delete(int id)
        {
            var item = Products.FirstOrDefault(p => p.Product_Id == id);
            Products.Remove(item);

            if (!(Products.Exists(p => p.Product_Id == id)))
                return StatusCode(200);
            else
                return NoContent();
            
        }

    }
}

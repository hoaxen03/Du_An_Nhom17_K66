using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Quan_Ly_Quy_Core_API.Models;
using System.Threading.Tasks;

namespace Quan_Ly_Quy_Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> ls_products = new List<Product> {
            new Product { Id = 1, Name = "Tivi Sony", Price = 1000},
            new Product { Id = 2, Name = "Tivi LG", Price = 2000 },
            new Product { Id = 3, Name = "Tivi SamSung", Price = 2200 }
        };

        //public void AddProduct()
        //{
        //    Product pd1 = new Product();
        //    pd1.Id = 1;
        //    pd1.Name = "Tivi ABC";
        //    pd1.Price = 500;
        //    ProductController.ls_products.Add(pd1);
        //}

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return ls_products.OrderByDescending(i => i.Id).AsEnumerable();
        }

        [HttpGet]
        [Route("{id}")]
        public Product GetProduct(int id)
        {
            return ls_products.FirstOrDefault(i => i.Id == id);
        }

        [HttpGet]
        [Route("search/{keyword}")]
        public IEnumerable<Product> SearchName(string keyword)
        {
            return ls_products.Where(i => i.Name.ToLower().Contains(keyword.ToLower()));
        }


        //[HttpPost]
        //[Route("add")]
        //public void AddProduct(int id, string name, double price)
        //{
        //    try
        //    {
        //        var prod = new Product() { Id = id, Name = name, Price = price };
        //        ls_products.Add(prod);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}


        [HttpPost]
        [Route("add")]
        public HttpResponseMessage AddProduct([FromBody] Product prod)
        {
            try
            {
                ls_products.Add(prod);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        //[HttpPost]
        //[Route("add")]
        //public IActionResult AddProduct([FromForm]Product prod) //FromForm | FromBody
        //{
        //    try
        //    {
        //        ls_products.Add(prod);
        //        return Ok(ls_products);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.ToString());
        //    }
        //}


        //[HttpPost]
        //[Route("add")]
        //public async Task<JsonResult> AddProduct([FromForm] Product prod) //FromForm | FromBody
        //{
        //    try
        //    {
        //        ls_products.Add(prod);
        //        return new JsonResult(ls_products);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(ex.ToString());
        //    }
        //}


        //[HttpPut]
        //[Route("update/{id}")]
        //public HttpResponseMessage UpdateProduct([FromForm] Product prod)
        //{
        //    try
        //    {
        //        // Tìm đối tượng với ID
        //        var prod_by_id = ls_products.Find(i => i.Id == prod.Id);

        //        if (prod_by_id.Id != null)
        //        {
        //            prod_by_id.Name = prod.Name;
        //            prod_by_id.Price = prod.Price;
        //            return new HttpResponseMessage(HttpStatusCode.OK);
        //        }
        //        else
        //        {
        //            throw new Exception("msg: Đối tượng không tồn tại");
        //            return new HttpResponseMessage(HttpStatusCode.OK);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}


        [HttpPut]
        [Route("update/{id}")]
        public async Task<JsonResult> UpdateProduct(int id, Product prod)
        {
            try
            {
                // Tìm đối tượng với ID
                var prod_old = ls_products.Find(i => i.Id == prod.Id);

                if (prod_old != null)
                {
                    var prod_new = prod;

                    prod_old.Name = prod_new.Name;
                    prod_old.Price = prod_new.Price;

                    return new JsonResult(prod);
                }
                else
                {
                    throw new Exception("msg: Đối tượng không tồn tại");
                    return new JsonResult("msg: Đối tượng không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                // Tìm đối tượng Product theo ID
                var prod_by_id = ls_products.Find(i => i.Id == id);

                if (prod_by_id.Id != null)
                {
                    ls_products.Remove(prod_by_id);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("msg: Đối tượng không tồn tại");
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("delete/all")]
        public HttpResponseMessage DeleteProduct()
        {
            try
            {
                ls_products.Clear();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

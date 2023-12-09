using Quan_Ly_Quy_Core_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Xml.Linq;

    namespace Quan_Ly_Quy_Core_API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class KhoanChiController : ControllerBase
        {
            private static List<KhoanChi> ls_KhoanChi = new List<KhoanChi> {
            new KhoanChi { Id = 1 ,TenKhoanChi = "8/3", SoLuongChi = 33, SoTienCanChi = 3300,NgayChi=8,NamChi=2023},
            new KhoanChi { Id = 2 ,TenKhoanChi = "mua phấn", SoLuongChi = 2, SoTienCanChi = 30000,NgayChi=14,NamChi=2023},
        };
            private int id;
            //public void AddProduct()
            //{
            //    Product pd1 = new Product();
            //    pd1.Id = 1;
            //    pd1.Name = "Tivi ABC";
            //    pd1.Price = 500;
            //    ProductController.ls_products.Add(pd1);
            //}

            [HttpGet]
            public IEnumerable<KhoanChi> GetKhoanChis()
            {
                return ls_KhoanChi.OrderByDescending(i => i.Id).AsEnumerable();
            }

            [HttpGet]
            [Route("{id}")]
            public KhoanChi GetKhoanChi(string tenKhoanChi)
            {
                return ls_KhoanChi.FirstOrDefault(i => i.Id == id);
            }

            [HttpGet]
            [Route("search/{keyword}")]
            public IEnumerable<KhoanChi> SearchName(string keyword)
            {
                return ls_KhoanChi.Where(i => i.TenKhoanChi.ToLower().Contains(keyword.ToLower()));
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
            public HttpResponseMessage AddProduct([FromBody] KhoanChi prod)
            {
                try
                {
                    ls_KhoanChi.Add(prod);
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
            public async Task<JsonResult> UpdateProduct(int id, KhoanChi prod)
            {
                try
                {
                    // Tìm đối tượng với ID
                    var prod_old = ls_KhoanChi.Find(i => i.Id == prod.Id);

                    if (prod_old != null)
                    {
                        var prod_new = prod;

                        prod_old.SoLuongChi = prod_new.SoLuongChi;
                        prod_old.SoTienCanChi = prod_new.SoTienCanChi;
                        prod_old.NgayChi = prod_new.NgayChi;
                        prod_old.NamChi = prod_new.NamChi;

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
                    var prod_by_id = ls_KhoanChi.Find(i => i.Id == id);

                    if (prod_by_id.Id != null)
                    {
                        ls_KhoanChi.Remove(prod_by_id);
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
                    ls_KhoanChi.Clear();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }
    

}
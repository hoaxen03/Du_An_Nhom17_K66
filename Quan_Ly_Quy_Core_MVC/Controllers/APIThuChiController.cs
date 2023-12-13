using Quan_Ly_Quy_Core_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Xml.Linq;

    namespace Quan_Ly_Quy_Core_API.Controllers
    {
        [Route("api/ThuChi")]
        [ApiController]
        public class APIThuChiController : ControllerBase
        {
            private static List<ThuChi> ls_ThuChi = new List<ThuChi> {
            new ThuChi { Id = 1 ,TenKhoanChi = "8/3", Loai1 ="Chi", SoTien = 3300,NgayChi=8/3/2023},
            new ThuChi {Id = 3 ,TenKhoanChi ="Bán sắt vụn",Loai1 ="Thu",SoTien = 50000,NgayChi=7/10/2023},
            new ThuChi { Id = 2 ,TenKhoanChi = "mua phấn",Loai1="Chi", SoTien = 30000,NgayChi=14 / 5 / 2023},
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
            public IEnumerable<ThuChi> GetThuChi()
            {
                return ls_ThuChi.OrderByDescending(i => i.Id).AsEnumerable();
            }

            [HttpGet]
            [Route("{id}")]
            public ThuChi GetKhoanChi(string tenKhoanChi)
            {
                return ls_ThuChi.FirstOrDefault(i => i.Id == id);
            }

            [HttpGet]
            [Route("search/{keyword}")]
            public IEnumerable<ThuChi> SearchName(string keyword)
            {
                return ls_ThuChi.Where(i => i.TenKhoanChi.ToLower().Contains(keyword.ToLower()));
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
            public HttpResponseMessage AddProduct([FromBody] ThuChi prod)
            {
                try
                {
                    ls_ThuChi.Add(prod);
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
            public async Task<JsonResult> UpdateProduct(int id, ThuChi prod)
            {
                try
                {
                    // Tìm đối tượng với ID
                    var prod_old = ls_ThuChi.Find(i => i.Id == prod.Id);

                    if (prod_old != null)
                    {
                        var prod_new = prod;

                        prod_old.Loai1 = prod_new.Loai1;
                        prod_old.SoTien = prod_new.SoTien;
                        prod_old.NgayChi = prod_new.NgayChi;

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
                    var prod_by_id = ls_ThuChi.Find(i => i.Id == id);

                    if (prod_by_id.Id != null)
                    {
                        ls_ThuChi.Remove(prod_by_id);
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
                    ls_ThuChi.Clear();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
        }
    

}
using Core_WebApp_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_WebAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class APIStudentController : ControllerBase
    {
        // Định nghĩa ra biến danh sách sinh viên; Để lưu sinh viên khi được add thêm mới
        public static List<Student> ds_sinhvien = new List<Student>()
            {
                new Student()
                {
                    Msv         = "221070001"   ,
                    Lop         = "66-HTTT"     ,
                    Khoavien    = "Khoa CĐCT"   ,
                    Cccd        = "0011234534"  ,
                    Hodem       = "Nguyễn Văn"  ,
                    Ten         = "ABC"      ,
                    Bietdanh    = "ABC"      ,
                    Email       = "abc@demo.com",
                    Dienthoai   = "0979xxxx222" ,
                    Tuoi        = 0
                },
                new Student()
                {
                    Msv         = "221070002"   ,
                    Lop         = "66-HTTT"     ,
                    Khoavien    = "Khoa CĐCT"   ,
                    Cccd        = "0011234534"  ,
                    Hodem       = "Trần Văn"  ,
                    Ten         = "XYZ"      ,
                    Bietdanh    = "XYZ"      ,
                    Email       = "abc@demo.com",
                    Dienthoai   = "0979xxxx242" ,
                    Tuoi        = 0
                },
                new Student()
                {
                    Msv         = "221070003"   ,
                    Lop         = "66-HTTT"     ,
                    Khoavien    = "Khoa CĐCT"   ,
                    Cccd        = "0011234534"  ,
                    Hodem       = "Lê Thị"  ,
                    Ten         = "AAA"      ,
                    Bietdanh    = "AAA"      ,
                    Email       = "aaa@demo.com",
                    Dienthoai   = "0979xxxx223" ,
                    Tuoi        = 0
                }
            };

        public static Student GetStudentByMsv(string msv)
        {
            //return ds_sinhvien.Find(i => i.Msv == msv);
            return ds_sinhvien.Where(i => i.Msv.ToLower().Contains(msv.ToLower())).First();
        }

        public static Student GetStudentByEmail(string email)
        {
            //return ds_sinhvien.Find(i => i.Msv == msv);
            return ds_sinhvien.Where(i => i.Email.ToLower().Contains(email.ToLower())).First();
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            // Trả về kết quả cho giao diện API
            return ds_sinhvien.OrderByDescending(i => i.Msv).AsEnumerable();
        }

        // GET api/<StudentController>/221070001
        [HttpGet("{msv}")]
        public Student Get(string msv)
        {
            return ds_sinhvien.FirstOrDefault(i => i.Msv == msv);
        }

        // GET api/<StudentController>/search/keyword
        [HttpGet("search/{keyword}")]
        public IEnumerable<Student> Search(string keyword)
        {
            return ds_sinhvien.Where(i => i.Ten.ToLower().Contains(keyword.ToLower()));
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student sv)
        {
            try
            {
                ds_sinhvien.Add(sv);
                return Ok(ds_sinhvien);
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }

        //// POST api/<StudentController>
        //[HttpPost]
        //public HttpResponseMessage Post([FromBody] Student sv)
        //{
        //    try
        //    {
        //        ds_sinhvien.Add(sv);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}

        // PUT api/<StudentController>/5
        [HttpPut("{msv}")]
        public IActionResult Put(string msv, [FromForm] Student sv)
        {
            // PUT là dể update: Khi sử dụng phải gửi 1 bản ghi đầy đủ các trường thông tin để yêu cầu cập nhật.
            // Lưu ý: Nếu các trường thông tin khác để trống --> khi cập nhật sẽ xóa (bỏ trống hoặc chứa giá trị null)
            try
            {
                if (sv == null)
                {
                    throw new ArgumentNullException("item");
                }
                int index = ds_sinhvien.FindIndex(p => p.Msv == sv.Msv);
                if (index == -1)
                {
                    return BadRequest("Msg: Mã sinh viên không tồn tại");
                }
                ds_sinhvien.RemoveAt(index);
                ds_sinhvien.Add(sv);
                return Ok(ds_sinhvien);

            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }





        }


        // PATCH api/<StudentController>/5
        [HttpPatch("{msv}")]
        public IActionResult Patch(string msv, [FromBody] Student sv)
        {
            try
            {
                // B1: Kiểm tra sự tồn tài của đối tượng theo id
                if (msv != sv.Msv)
                    return BadRequest("Msg: Mã sinh viên không tồn tại");

                var sv_old = APIStudentController.GetStudentByMsv(msv);
                var sv_new = sv;

                // B2: Cập nhật các trường thông tin

                // B3: Thông báo kết quả
                return Ok(ds_sinhvien);
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{msv}")]
        public IActionResult DeleteByMsv(string msv)
        {
            try
            {
                var sv_del = APIStudentController.GetStudentByMsv(msv);
                // B1: Kiểm tra sự tồn tài của đối tượng theo id
                if (sv_del != null)
                {
                    ds_sinhvien.Remove(sv_del);
                    return Ok(ds_sinhvien);
                }
                else
                    return BadRequest("Msg: Mã sinh viên không tồn tại");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }

        // DELETE api/<StudentController>/all
        [HttpDelete()]
        public HttpResponseMessage DeleteAll()
        {
            try
            {
                ds_sinhvien.Clear();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

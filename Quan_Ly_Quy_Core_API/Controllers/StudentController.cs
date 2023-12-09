using Quan_Ly_Quy_Core_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quan_Ly_Quy_Core_API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Định nghĩa ra biến danh sách sinh viên; Để lưu sinh viên khi được add thêm mới
        public static List<Student> ds_SinhVien = new List<Student>()
            {
                new Student()
                {
                    Msv         = "221070001"   ,
                    Lop         = "66-HTTT"     ,
                    Khoavien    = "Khoa CĐCT"   ,
                    Cccd        = "0011234534"  ,
                    Hodem       = "Nguyễn Công"  ,
                    Ten         = "Văn"      ,
                    Bietdanh    = "Advankaynss"      ,
                    Email       = "abc@demo.com",
                    Dienthoai   = "0961xxxx527" ,
                    Tuoi        = 20,
                    Tien        = 100000
                },
                new Student()
                {
                    Msv         = "221070002"   ,
                    Lop         = "66-HTTT"     ,
                    Khoavien    = "Khoa CĐCT"   ,
                    Cccd        = "0011234534"  ,
                    Hodem       = "Phạm Thị"  ,
                    Ten         = "Lộc"      ,
                    Bietdanh    = "Phạm Lộc"      ,
                    Email       = "abcd@demo.com",
                    Dienthoai   = "0976xxxx222" ,
                    Tuoi        = 20,
                    Tien        =200000
                },
                new Student()
                {
                    Msv         = "221070003"   ,
                    Lop         = "66-HTTT"     ,
                    Khoavien    = "Khoa CĐCT"   ,
                    Cccd        = "0011234534"  ,
                    Hodem       = "Vũ Thành "  ,
                    Ten         = "Trung"      ,
                    Bietdanh    = "HoaXen"      ,
                    Email       = "aaa@demo.com",
                    Dienthoai   = "0979xxxx293" ,
                    Tuoi        = 20,
                    Tien        =300000
                }
            };


        public static Student GetStudentByMsv(string msv)
        {
            //return ds_sinhvien.Find(i => i.Msv == msv);
            return ds_SinhVien.Where(i => i.Msv.ToLower().Contains(msv.ToLower())).First();
        }

        public static Student GetStudentByEmail(string email)
        {
            //return ds_sinhvien.Find(i => i.Msv == msv);
            return ds_SinhVien.Where(i => i.Email.ToLower().Contains(email.ToLower())).First();
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            // Trả về kết quả cho giao diện API
            return ds_SinhVien.OrderByDescending(i => i.Msv).AsEnumerable();
        }

        // GET api/<StudentController>/221070001
        [HttpGet("{msv}")]
        public Student Get(string msv)
        {
            return ds_SinhVien.FirstOrDefault(i => i.Msv == msv);
        }

        // GET api/<StudentController>/search/keyword
        [HttpGet("search/{keyword}")]
        public IEnumerable<Student> Search(string keyword)
        {
            return ds_SinhVien.Where(i => i.Ten.ToLower().Contains(keyword.ToLower()));
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromForm] Student sv)
        {
            try
            {
                ds_SinhVien.Add(sv);
                return Ok(ds_SinhVien);
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
                int index = ds_SinhVien.FindIndex(p => p.Msv == sv.Msv);
                if (index == -1)
                {
                    return BadRequest("Msg: Mã sinh viên không tồn tại");
                }
                ds_SinhVien.RemoveAt(index);
                ds_SinhVien.Add(sv);
                return Ok(ds_SinhVien);

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

                var sv_old = StudentController.GetStudentByMsv(msv);
                var sv_new = sv;

                // B2: Cập nhật các trường thông tin

                // B3: Thông báo kết quả
                return Ok(ds_SinhVien);
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
                var sv_del = StudentController.GetStudentByMsv(msv);
                // B1: Kiểm tra sự tồn tài của đối tượng theo id
                if (sv_del != null)
                {
                    ds_SinhVien.Remove(sv_del);
                    return Ok(ds_SinhVien);
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
                ds_SinhVien.Clear();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

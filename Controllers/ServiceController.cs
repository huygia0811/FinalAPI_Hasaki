using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalAPI_Hasaki.Database;
namespace FinalAPI_Hasaki.Controllers
{
    public class ServiceController : ApiController
    {
        [Route("api/ServiceController/GetSPByLoai")]
        [HttpGet]
        public IHttpActionResult GetSPByLoai(int maloai)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("maloai", maloai);

                DataTable result = Database.Database.ReadTable("Proc_GetSPByLoai", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/GetSPByHang")]
        [HttpGet]
        public IHttpActionResult GetSPByHang(int mahang)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("mahang", mahang);

                DataTable result = Database.Database.ReadTable("Proc_GetSPByHang", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/GetHang")]
        [HttpGet]
        public IHttpActionResult GetHang()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetHang");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/GetDetailSP")]
        [HttpGet]
        public IHttpActionResult GetDetailSP(int masp)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("masp", masp);

                DataTable result = Database.Database.ReadTable("Proc_GetDetailSP", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/DangKy")]
        [HttpPost]
        public IHttpActionResult DangKy(NguoiDung nd)
        {
            try
            {
                NguoiDung kq = Database.Database.Them_Nguoi_Dung(nd);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

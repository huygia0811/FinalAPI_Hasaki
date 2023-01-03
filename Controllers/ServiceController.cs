﻿using System;
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
        [Route("api/ServiceController/Show_Trangthai_Info")]
        [HttpGet]
        public IHttpActionResult Show_Trangthai_Info(int trangthai, int makh)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("trangthai", trangthai);
                param.Add("makh", makh);
                DataTable result = Database.Database.ReadTable("Proc_info_from_trangthai", param);
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
                NguoiDung kq = Database.Database.DangKy_TaiKhoan(nd);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/DangNhap")]
        [HttpGet]
        public IHttpActionResult DangNhap(string SODIENTHOAI, string MATKHAU)
        {
            try
            {
                NguoiDung nd = Database.Database.DangNhap(SODIENTHOAI, MATKHAU);

                return Ok(nd);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/ThemGioHang")]
        [HttpGet]
        public IHttpActionResult ThemGioHang(int MAKH, int MASP, int soluong)
        {
            try
            {
                Database.Database.ThemGioHang(MAKH, MASP, soluong);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/ServiceController/SelectGioHang")]
        [HttpGet]
        public IHttpActionResult SelectGioHang(int MAKH)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("makh", MAKH);
                DataTable result = Database.Database.ReadTable("Proc_SelectGioHang", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/UpdateSLGioHang")]
        [HttpGet]
        public IHttpActionResult UpdateSLGioHang(int MAKH, int MASP, int sl_updated)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("makh", MAKH);
                param.Add("masp", MASP);
                param.Add("sl_updated", sl_updated);
                DataTable result = Database.Database.ReadTable("Proc_UpdateSLGioHang", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/DropSPGioHang")]
        [HttpGet]
        public IHttpActionResult DropSPGioHang(int MAKH, int MASP)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("makh", MAKH);
                param.Add("masp", MASP);
                DataTable result = Database.Database.ReadTable("Proc_DropSPGioHang", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

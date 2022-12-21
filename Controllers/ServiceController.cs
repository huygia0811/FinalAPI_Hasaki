using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalAPI_Hasaki.Controllers
{
    public class ServiceController : ApiController
    {
        [Route("api/ServiceController/GetAllSanPham")]
        [HttpGet]
        public IHttpActionResult GetAllSanPham()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllSanPham");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

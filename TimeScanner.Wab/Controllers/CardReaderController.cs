using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TimeScanner.Wab.Controllers
{
    public class CardReaderController : ApiController
    {
        [HttpGet]
        [Route("api/CardReader/{token}")]
        public DSA.EF.TempEmployee Read(string token)
        {
            var dac = new TimeScanner.DSA.EF.TimeScannerDBContainer();
            var emp = dac.TempEmployeeSet.Where(x => x.Token == token).FirstOrDefault();
            return emp;
        }
    }
}

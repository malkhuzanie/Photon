using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Photon.Models;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using System.Text;
using Photon.Services;
using Photon.Exceptions;

namespace Photon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController(ReportService service) : ControllerBase
    {

        [HttpGet("{facilityId:int}")]
        public async Task<IActionResult> GetItemsPdf(int facilityId)
        {
            try
            {
                var (pdfStream, fileName) = await service.GetItemsByFacilityId(facilityId);
                return File(pdfStream, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}

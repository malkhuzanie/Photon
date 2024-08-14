using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Photon.Models;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("Items_By_Facility/Pdf/{facilityId:int}")]
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

        [HttpGet("Users_By_Facility/Pdf/{facilityId:int}")]
        public async Task<IActionResult> GetUsersPdf(int facilityId)
        {
            try
            {
                var (pdfStream, fileName) = await service.GetUsersByFacilityId(facilityId);
                return File(pdfStream, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("Items_By_Facility/Excel/{facilityId:int}")]
        public async Task<IActionResult> GetItemsExcel(int facilityId)
        {
            try
            {
                var (excelStream, fileName) = await service.GetItemsByFacilityExcel(facilityId);
                return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("Users_By_Facility/Excel/{facilityId:int}")]
        public async Task<IActionResult> GetUsersExcel(int facilityId)
        {
            try
            {
                var (excelStream, fileName) = await service.GetUsersByFacilityExcel(facilityId);
                return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


    }
}

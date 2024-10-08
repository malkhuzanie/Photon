using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.DTOs.Response;
using Photon.Interfaces;
using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.Services;

public class InboundPurchaseOrderStatusService(PhotonContext context)
  : IEntityService<DTOs.Response.PurchaseOrderStatusResponseDto, PurchaseOrderStatusDto>
{
  public async Task<PurchaseOrderStatus> Cancelled()
  {
    return await context.InboundPurchaseOrderStatus
      .FirstAsync(s => s.Status.Equals("cancelled", StringComparison.CurrentCultureIgnoreCase));
  }
  
  public async Task<DTOs.Response.PurchaseOrderStatusResponseDto?> GetById(int id)
  {
    return await context.InboundPurchaseOrderStatus
      .Select(s => new DTOs.Response.PurchaseOrderStatusResponseDto { Id = s.Id, Status = s.Status})
      .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task<IEnumerable<DTOs.Response.PurchaseOrderStatusResponseDto>> GetAll()
  {
    return await context.InboundPurchaseOrderStatus
      .Select(s => new DTOs.Response.PurchaseOrderStatusResponseDto { Id = s.Id, Status = s.Status})
      .ToListAsync();
  }

  public Task<DTOs.Response.PurchaseOrderStatusResponseDto> Create(PurchaseOrderStatusDto arg)
  {
    throw new NotImplementedException();
  }

  public Task Update(int id, PurchaseOrderStatusDto arg)
  {
    throw new NotImplementedException();
  }

  public Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
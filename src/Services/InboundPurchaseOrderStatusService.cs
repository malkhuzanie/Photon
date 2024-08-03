using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Interfaces;
using Photon.Models;

namespace Photon.Services;

public class InboundPurchaseOrderStatusService(PhotonContext context)
  : IEntityService<DTOs.Response.PurchaseOrderStatusDto, PurchaseOrderStatusDto>
{
  public async Task<DTOs.Response.PurchaseOrderStatusDto?> GetById(int id)
  {
    return await context.InboundPurchaseOrderStatus
      .Select(s => new DTOs.Response.PurchaseOrderStatusDto { Id = s.Id, Status = s.Status})
      .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task<IEnumerable<DTOs.Response.PurchaseOrderStatusDto>> GetAll()
  {
    return await context.InboundPurchaseOrderStatus
      .Select(s => new DTOs.Response.PurchaseOrderStatusDto { Id = s.Id, Status = s.Status})
      .ToListAsync();
  }

  public async Task<DTOs.Response.PurchaseOrderStatusDto> Create(PurchaseOrderStatusDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task Update(int id, PurchaseOrderStatusDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
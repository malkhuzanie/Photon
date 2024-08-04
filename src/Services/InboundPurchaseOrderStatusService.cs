using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Interfaces;
using Photon.Models;

namespace Photon.Services;

public class InboundPurchaseOrderStatusService(PhotonContext context)
  : IEntityService<DTOs.Response.PurchaseOrderStatusResponseDto, PurchaseOrderStatusDto>
{
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

  public async Task<DTOs.Response.PurchaseOrderStatusResponseDto> Create(PurchaseOrderStatusDto arg)
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
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Response;
using Photon.Interfaces;
using Photon.Models;

using StatusRequestDto = Photon.DTOs.Request.PurchaseOrderStatusDto;

namespace Photon.Services;

public class OutboundPurchaseOrderStatusService(PhotonContext context)
  : IEntityService<PurchaseOrderStatusResponseDto, StatusRequestDto>
{
  public async Task<PurchaseOrderStatusResponseDto?> GetById(int id)
  {
    return await context.OutboundPurchaseOrderStatus
      .Select(s => new PurchaseOrderStatusResponseDto { Id = s.Id, Status = s.Status})
      .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task<IEnumerable<PurchaseOrderStatusResponseDto>> GetAll()
  {
    return await context.OutboundPurchaseOrderStatus
      .Select(s => new PurchaseOrderStatusResponseDto { Id = s.Id, Status = s.Status})
      .ToListAsync();
  }

  public Task<PurchaseOrderStatusResponseDto> Create(StatusRequestDto arg)
  {
    throw new NotImplementedException();
  }

  public Task Update(int id, StatusRequestDto arg)
  {
    throw new NotImplementedException();
  }

  public Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
}

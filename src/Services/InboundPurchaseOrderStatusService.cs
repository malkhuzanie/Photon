using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Interfaces;
using Photon.Models;

using StatusRequestDto = Photon.DTOs.Request.InboundPurchaseOrderStatusDto;
using StatusResponseDto = Photon.DTOs.Response.InboundPurchaseOrderStatusDto;
namespace Photon.Services;

public class InboundPurchaseOrderStatusService(PhotonContext context)
  : IEntityService<StatusResponseDto, StatusRequestDto>
{
  public async Task<StatusResponseDto?> GetById(int id)
  {
    return await context.InboundPurchaseOrderStatus
      .Select(s => new StatusResponseDto { Id = s.Id, Status = s.Status})
      .FirstOrDefaultAsync(s => s.Id == id);
  }

  public async Task<IEnumerable<StatusResponseDto>> GetAll()
  {
    return await context.InboundPurchaseOrderStatus
      .Select(s => new StatusResponseDto { Id = s.Id, Status = s.Status})
      .ToListAsync();
  }

  public async Task<StatusResponseDto> Create(StatusRequestDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task Update(int id, StatusRequestDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
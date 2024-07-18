using Photon.Data;
using Photon.DTOs;
using Photon.Interfaces;

namespace Photon.Services;

public class InboundPurchaseOrder(PhotonContext context)
  : IEntityService<InboundPurchaseOrder, InboundPurchaseOrderDto>
{
  public async Task<InboundPurchaseOrder?> GetById(int id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<InboundPurchaseOrder>> GetAll()
  {
    throw new NotImplementedException();
  }

  public async Task<InboundPurchaseOrder> Create(InboundPurchaseOrderDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task Update(int id, InboundPurchaseOrderDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
}
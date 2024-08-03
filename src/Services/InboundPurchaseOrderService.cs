using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models;
using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Services;

public class InboundPurchaseOrderService(PhotonContext context)
  : IEntityService<InboundPurchaseOrder, InboundPurchaseOrderDto>
{
  public async Task<InboundPurchaseOrder?> GetById(int id)
  {
    return await context.InboundPurchaseOrders
      .Include(ibpo => ibpo.Facility)
      .Include(ibpo => ibpo.Supplier)
      .Include(ibpo => ibpo.Items)
      .Include(ibpo => ibpo.Status)
      .FirstOrDefaultAsync(ipo => ipo.PoNbr == id);
  }

  public async Task<IEnumerable<InboundPurchaseOrder>> GetAll()
  {
    return await context.InboundPurchaseOrders
      .Include(ibpo => ibpo.Facility)
      .Include(ibpo => ibpo.Supplier)
      .Include(ibpo => ibpo.Items)
      .Include(ibpo => ibpo.Status)
      .ToListAsync();
  }

  public async Task<InboundPurchaseOrder> Create(InboundPurchaseOrderDto _po)
  {
    var ibpo = await _po.ToInboundPurchaseOrder(context);
    context.InboundPurchaseOrders.Add(ibpo);
    await context.SaveChangesAsync();
    return ibpo;
  }

  public async Task Update(int id, InboundPurchaseOrderDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int poNbr)
  {
    if (await context.InboundPurchaseOrders.FindAsync(poNbr) is not {} ibpo)
    {
      return false;
    }
    context.Remove(ibpo);
    await context.SaveChangesAsync();
    return true;
  }
}

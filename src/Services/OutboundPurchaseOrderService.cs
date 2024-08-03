using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Interfaces;
using Photon.Models.PurchaseOrder.Outbound;
using Photon.Mapping;

namespace Photon.Services;

public class OutboundPurchaseOrderService(PhotonContext context)
  : IEntityService<OutboundPurchaseOrder, OutboundPurchaseOrderDto>
{
  public async Task<OutboundPurchaseOrder?> GetById(int id)
  {
    return await context.OutboundPurchaseOrders
      .Include(ibpo => ibpo.Facility)
      .Include(ibpo => ibpo.Customer)
      .Include(ibpo => ibpo.Items)
      .Include(ibpo => ibpo.Status)
      .FirstOrDefaultAsync(ipo => ipo.PoNbr == id);
  }

  public async Task<IEnumerable<OutboundPurchaseOrder>> GetAll()
  {
    return await context.OutboundPurchaseOrders
      .Include(ibpo => ibpo.Facility)
      .Include(ibpo => ibpo.Customer)
      .Include(ibpo => ibpo.Items)
      .Include(ibpo => ibpo.Status)
      .ToListAsync();
  }

  public async Task<OutboundPurchaseOrder> Create(OutboundPurchaseOrderDto _po)
  {
    var in_po = await _po.ToOutboundPurchaseOrder(context);
    context.OutboundPurchaseOrders.Add(in_po);
    await context.SaveChangesAsync();
    return in_po;
  }

  public async Task Update(int id, OutboundPurchaseOrderDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int poNbr)
  {
    if (await context.OutboundPurchaseOrders.FindAsync(poNbr) is not {} ibpo)
    {
      return false;
    }
    context.Remove(ibpo);
    await context.SaveChangesAsync();
    return true;
  }
}

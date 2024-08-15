using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models.PurchaseOrder.Outbound;

namespace Photon.Services;

public class OutboundPurchaseOrderService(PhotonContext context)
  : IEntityService<OutboundPurchaseOrder, OutboundPurchaseOrderDto>
{
  public async Task<OutboundPurchaseOrder?> GetById(int id)
  {
    return await context.OutboundPurchaseOrders
      .Include(po => po.Facility)
      .Include(po => po.Customer)
      .Include(po => po.Items)
      .Include(po => po.Status)
      .FirstOrDefaultAsync(po => po.PoNbr == id);
  }

  public async Task<IEnumerable<OutboundPurchaseOrder>> GetAll()
  {
    return await context.OutboundPurchaseOrders
      .Include(po => po.Facility)
      .Include(po => po.Customer)
      .Include(po => po.Items)
      .Include(po => po.Status)
      .ToListAsync();
  }

  public async Task<OutboundPurchaseOrder> Create(OutboundPurchaseOrderDto _po)
  {
    var po = await _po.ToOutboundPurchaseOrder(context);
    context.OutboundPurchaseOrders.Add(po);
    await context.SaveChangesAsync();
    return po;
  }

  public async Task Update(int poNbr, OutboundPurchaseOrderDto _po)
  {
    var po = await GetById(poNbr);
    if (po == null)
    {
      throw new NotFoundException("Purchase order is not found in the database");
    }

    po.UpdateFrom(await _po.ToOutboundPurchaseOrder(context));
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int poNbr)
  {
    if (await context.OutboundPurchaseOrders.FindAsync(poNbr) is not { } ibpo)
    {
      return false;
    }

    context.Remove(ibpo);
    await context.SaveChangesAsync();
    return true;
  }
}
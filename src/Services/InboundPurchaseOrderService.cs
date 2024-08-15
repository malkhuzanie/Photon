using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.SignalR.Hubs;

namespace Photon.Services;

public class InboundPurchaseOrderService(
  PhotonContext context,
  IHubContext<NotificationHub> hub)
  : IEntityService<InboundPurchaseOrder, InboundPurchaseOrderDto>
{
  public async Task<InboundPurchaseOrder?> GetById(int id)
  {
    return await context.InboundPurchaseOrders
      .Include(ibpo => ibpo.Facility)
      .Include(ibpo => ibpo.Supplier)
      .Include(ibpo => ibpo.PoItems)
      .ThenInclude(item => item.ItemPickupStatus)
      .Include(ibpo => ibpo.Status)
      .FirstOrDefaultAsync(ipo => ipo.PoNbr == id);
  }

  public Task<IEnumerable<InboundPurchaseOrder>> GetAll()
  {
    throw new NotImplementedException();
  }
  
  public async Task<IEnumerable<InboundPurchaseOrder>> GetAll(
    DateTime? startDate, 
    DateTime? endDate)
  {
    IQueryable<InboundPurchaseOrder> query = context.InboundPurchaseOrders
      .Include(ibpo => ibpo.Facility)
      .Include(ibpo => ibpo.Supplier)
      .Include(ibpo => ibpo.PoItems)
      .ThenInclude(item => item.ItemPickupStatus)
      .Include(ibpo => ibpo.Status);

    startDate ??= DateTime.MinValue;
    endDate ??= DateTime.MaxValue;
    
    return await query
      .Where(po => po.OrderDate >= startDate && po.OrderDate <= endDate)
      .ToListAsync();
  }

  public async Task<InboundPurchaseOrder> Create(InboundPurchaseOrderDto _po)
  {
    var ibpo = await _po.ToInboundPurchaseOrder(context);
    context.InboundPurchaseOrders.Add(ibpo);
    await context.SaveChangesAsync();
    return ibpo;
  }

  public async Task Update(int poNbr, InboundPurchaseOrderDto _po)
  {
    var po = await GetById(poNbr);
    if (po == null)
    {
      throw new NotFoundException("Purchase order is not found in the database");
    }

    po.UpdateFrom(await _po.ToInboundPurchaseOrder(context));
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int poNbr)
  {
    if (await context.InboundPurchaseOrders.FindAsync(poNbr) is not { } ibpo)
    {
      return false;
    }

    context.Remove(ibpo);
    await context.SaveChangesAsync();
    return true;
  }
}
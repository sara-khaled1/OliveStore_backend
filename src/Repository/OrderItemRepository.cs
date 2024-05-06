using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Database;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repository;

public class OrderItemRepository : IOrderItemRepository
{
    private DatabaseContext _databaseContext;
    private DbSet<OrderItem> _orderItems { get; set; }

    public OrderItemRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _orderItems = databaseContext.OrderItems;
    }

    public IEnumerable<OrderItem> FindAll()
    {
        return _orderItems;
    }
    public OrderItem? FindOne(Guid id)
    {
        OrderItem? orderItem = _orderItems.FirstOrDefault(orderItem => orderItem.Id == id);
        if (orderItem is not null)
        {
            return orderItem;
        }
        else return null;
    }

    public OrderItem CreateOne(OrderItem orderItem)
    {
        _orderItems.Add(orderItem);
        _databaseContext.SaveChanges();
        return orderItem;
    }

    public OrderItem UpdateOne(OrderItem updatedOrderItem)
    {
        _orderItems.Update(updatedOrderItem);
        _databaseContext.SaveChanges();
        return updatedOrderItem;

    }

    public bool DeleteOne(Guid id)
    {
        OrderItem? orderItem = FindOne(id);
        if (orderItem is null) return false;
        _orderItems.Remove(orderItem);
        _databaseContext.SaveChanges();
        return true;

    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public interface IInventoryRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(int itemId, out int AvailableQty);
    }

    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int orderId);
        void CreateOrder(Order order);
    }

    public interface IBillingRepository
    {
        IEnumerable<Billing> GetAllBills();
        Billing GetBilling(int billingId);
    }

    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetPayment(int pamentId);
    }

    public interface IShoppingCartRepository
    {
        List<ShoppingCartItem> GetAllCartItems();
        ShoppingCartItem GetCartItem(int ItemId);
        void AddItemToCart(Item item);
        void RemoveItemFromCart(Item item);
        void RemoveShoppingCartItemFromCart(ShoppingCartItem cartItem);
        void ClearCart();
    }
}

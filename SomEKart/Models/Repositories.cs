using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        AppDbContext _context;
        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Inventories.ToList();
        }

        public Item GetItem(int itemId, out int AvailableQty)
        {
            AvailableQty = 0;
            var items =_context.Inventories.Where(a=> a.Id == itemId).ToList();
            AvailableQty = items.Count();
            return items[0];
        }
    }

    public class ShoppingCartRepository : IShoppingCartRepository
    {
        AppDbContext _context;
        public string ShoppingCartId { get; set; }

        private ShoppingCartRepository(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Item item)
        {
            var cartItem = _context.ShoppingCartItems.FirstOrDefault(a => a.ItemId == item.Id && a.ShoppingCartId == ShoppingCartId);
            if (cartItem == null)
            {
                _context.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    ItemId = item.Id,
                    ItemName = item.Name,
                    Price = item.Price,
                    Quantity = 1,
                    Amount = item.Price
                });
            }
            else
            {
                cartItem.Quantity++;
                cartItem.Amount += item.Price;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Item item)
        {
            var cartItem = _context.ShoppingCartItems.FirstOrDefault(a => a.ItemId == item.Id && a.ShoppingCartId == ShoppingCartId);
            if (cartItem != null)
            {
                _context.ShoppingCartItems.Remove(cartItem);
            }

            _context.SaveChanges();
        }
        
        public void ClearCart()
        {
            var itemRange = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            _context.ShoppingCartItems.RemoveRange(itemRange);
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetAllCartItems()
        {
            return _context.ShoppingCartItems.Where(a=> a.ShoppingCartId == ShoppingCartId).ToList();
        }

        public ShoppingCartItem GetCartItem(int itemId)
        {
            return _context.ShoppingCartItems.FirstOrDefault(a => a.ItemId == itemId && a.ShoppingCartId == ShoppingCartId);
        }

    }
}
 
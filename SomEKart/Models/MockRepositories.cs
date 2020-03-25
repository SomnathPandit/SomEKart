using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public class MockInvertoryRepository : IInventoryRepository
    {
        List<Item> _items = null;

        public MockInvertoryRepository()
        {
            _items = new List<Item>() {
                new Item(){ Id=1, Name="FormalShoe 1", Size=10, Color= ItemColors.Black, Price=1899, Description="Men's Black formal shoe for office use", ImageUrl="/images/formal-shoe-black.jpg"},
                new Item(){ Id=2, Name="CasualShoe 1", Size=10, Color= ItemColors.Black, Price=2299, Description="Men's Navy Blue Slip-On Sneakers", ImageUrl="/images/casual-shoe-black.jpg"},
                new Item(){ Id=3, Name="FormalShoe 2", Size=9, Color= ItemColors.Brown, Price=2799, Description="Men's Brown formal shoe for office use", ImageUrl="/images/formal-shoe-brown.jpg"}
            };
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _items;
        }

        public Item GetItem(int itemId, out int AvailableQty)
        {
            AvailableQty = 1;
            return _items.Find(a => a.Id == itemId);
        }
    }

}

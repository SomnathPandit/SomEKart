using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public class Item: BaseModel
    {
        public Category Category { get; set; }
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ItemColors Color { get; set; }
        public int Size { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Neutral
    }

    public enum Category
    {
        Footware,
        Topware,
        Bottomware,
        Others
    }

    public enum ItemColors
    {
        White,
        Black,
        Brown,
        Red,
        Green,
        Blue,
        Pink
    }

    public class Product : BaseModel
    {
        public int ItemId { get; set; }
    }
}

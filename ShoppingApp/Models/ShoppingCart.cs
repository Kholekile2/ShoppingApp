using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class ShoppingCart
    {
        [PrimaryKey, AutoIncrement]
        public int CartItemId { get; set; }

        [ForeignKey(typeof(ShoppingItems))]
        public int ShoppingItemId { get; set; }

        [ManyToOne]
        public ShoppingItems ShoppingItem { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(typeof(CustomerProfile))]
        public int CustomerProfileId { get; set; }

        public ShoppingCart()
        {
            ShoppingItem = new ShoppingItems();
        }
    }
}

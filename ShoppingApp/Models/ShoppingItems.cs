using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingApp.Models
{
    public class ShoppingItems
    {

        [PrimaryKey, AutoIncrement]
        public int ShoppingItemsId { get; set; }

        public int CustomerProfileId { get; set; }

        public string ItemsName { get; set; }

        public string ItemsPrice { get; set; }

        public int ItemsQuantity { get; set; }

        public string ItemImage { get; set; }

    }
}

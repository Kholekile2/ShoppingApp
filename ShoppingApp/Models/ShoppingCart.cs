using SQLite;
using SQLiteNetExtensions.Attributes;
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
        public int ShoppingCartId { get; set; }

        [ForeignKey(typeof(CustomerProfile))]
        
        public int CustomerProfileId { get; set;}

        [OneToMany(CascadeOperations = CascadeOperation.All)]

        public List<ShoppingItems> ShoppingItems { get; set; }

    }
}

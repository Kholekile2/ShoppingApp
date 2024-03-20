using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class CustomerProfile
    {
        [PrimaryKey, AutoIncrement]
        public int CustomerProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Bio {  get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]

        public List<ShoppingItems> shoppingItems { get; set; }


    }
}

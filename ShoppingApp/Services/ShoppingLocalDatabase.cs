using ShoppingApp.Models;
using SQLite;
using System.Collections;
using System;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;


namespace ShoppingApp.Services
{
    public class ShoppingLocalDatabase
    {
        private SQLiteConnection _dbconnection;

        public string GetDatabasePath()
        {
            string filename = "shoppingdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //return pathToDb + filename;
            return Path.Combine(pathToDb, filename);
            
        }

        public ShoppingLocalDatabase()
        {
            _dbconnection = new SQLiteConnection(GetDatabasePath());

            _dbconnection.CreateTable<CustomerProfile>();
            _dbconnection.CreateTable<ShoppingCart>();
            _dbconnection.CreateTable<ShoppingItems>();

            SeedDatabase();
        }

        public void SeedDatabase()
        {
            
            if (_dbconnection.Table<CustomerProfile>().Count()==0)
            {
                CustomerProfile customerProfile = new CustomerProfile()
                {
                    Name = "Kiddo",
                    Surname = "Mpengesi",
                    EmailAddress = "kmp@kiddo.com",
                    Bio = "This is hectic",
                };
                _dbconnection.Insert(customerProfile);
            }
            
            if (_dbconnection.Table<ShoppingItems>().Count()==0) 
            {
                List<ShoppingItems> items = new List<ShoppingItems>()
                //ShoppingItems customerItems = new ShoppingItems()
                {

                    new ShoppingItems()
                    {
                        ItemsName = "Converse",
                        ItemsPrice = "R1 499.99",
                        ItemsQuantity = 50,
                        ItemImage = "converse.jpeg",
                    },

                    new ShoppingItems()
                    {
                        ItemsName = "Reebok",
                        ItemsPrice = "R1 350.00",
                        ItemsQuantity = 20,
                        ItemImage = "reebok.jpeg",
                    },

                    new ShoppingItems()
                    {
                        ItemsName = "Superga",
                        ItemsPrice = "R750.00",
                        ItemsQuantity = 10,
                        ItemImage = "superga.jpeg",
                    },

                    new ShoppingItems()
                    {
                        ItemsName = "Superstar",
                        ItemsPrice = "R800.00",
                        ItemsQuantity = 10,
                        ItemImage = "superstar.jpeg",
                    },
                    
                };
                _dbconnection.InsertAll(items);

            }
        }

        public void AddToCart(ShoppingItems item, int quantity, int customerProfileId)
        {
            var cartItem = new ShoppingCart
            {
                ShoppingItem = item,
                Quantity = quantity,
                CustomerProfileId = customerProfileId
            };

            _dbconnection.Insert(cartItem);
        }

        public List<ShoppingItems> GetAllShoppingItems()
        {
            return _dbconnection.Table<ShoppingItems>().ToList();
        }

        public ShoppingItems GetItemsById(int id)
        {
            ShoppingItems items = _dbconnection.Table<ShoppingItems>().Where(x => x.ShoppingItemsId == id).FirstOrDefault();
            return items;
        }

        public void UpdateShoppingItems(ShoppingItems shoppingItems)
        {
            _dbconnection.Update(shoppingItems);
        }

        public List<CustomerProfile> GetAllCutomerProfile()
        {
            return _dbconnection.Table<CustomerProfile>().ToList();
        }

        public CustomerProfile GetCustumerProfileById(int id)
        {
            CustomerProfile customerProfile = _dbconnection.Table<CustomerProfile>().Where(x => x.CustomerProfileId == id).FirstOrDefault();
            return customerProfile;
        }

        public void UpdateCustomerPrile(CustomerProfile customerProfile)
        {
            _dbconnection.Update(customerProfile);
        }   
    }
}

using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.Pages
{
    public partial class ProductPage : ContentPage
    {
        private readonly ShoppingLocalDatabase _database;

        public ProductPage(ShoppingLocalDatabase database)
        {
            InitializeComponent();
            _database = database;
            LoadShoppingItems();
        }

        private void LoadShoppingItems()
        {
            var items = _database.GetAllShoppingItems();
            itemListView.ItemsSource = items;
        }
    }
}

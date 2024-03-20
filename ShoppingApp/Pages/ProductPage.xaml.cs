using ShoppingApp.Models;
using ShoppingApp.Services;
using System.Collections.ObjectModel;

namespace ShoppingApp.Pages
{
    public partial class ProductPage : ContentPage
    {
        private ShoppingLocalDatabase _database;
        private ObservableCollection<ShoppingItems> _items;

        public ObservableCollection<ShoppingItems> Items
        {
            get { return _items; }
            set
            {
                _items = value;

                OnPropertyChanged(nameof(Items));

            }
        }

        public ProductPage()
        {
            InitializeComponent();
            _database = new ShoppingLocalDatabase();
            BindingContext = this;
            LoadData();


        }

        private void LoadData()
        {
            // _currentCustomer = _database.GetCustomerById(1);
            Items = new ObservableCollection<ShoppingItems>(_database.GetAllShoppingItems());
            //ShoppingItemsListView.BindingContext = Items;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData(); // Reload data every time the page appears
        }

        /*private void AddShoppingItems_clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var shoppingItems = (ShoppingItems)button.CommandParameter;
        }*/
    }
}
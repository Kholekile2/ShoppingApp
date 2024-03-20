using ShoppingApp.Models;
using ShoppingApp.Services;
using System.Collections.ObjectModel;

namespace ShoppingApp.Pages;

public partial class CartPage : ContentPage
{
    private ObservableCollection<ShoppingCart> _cartItems;

    public ObservableCollection<ShoppingCart> CartItems
    {
        get { return _cartItems; }
        set
        {
            _cartItems = value;
            OnPropertyChanged();
        }
    }

    public CartPage()
    {
        InitializeComponent();
        CartItems = new ObservableCollection<ShoppingCart>(); // Initialize the cart items collection
        BindingContext = this;
    }

    // Method to add item to the cart
    public void AddToCart(ShoppingItems item, int quantity)
    {
        var existingCartItem = CartItems.FirstOrDefault(c => c.ShoppingItemId == item.ShoppingItemId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += quantity;
        }
        else
        {
            CartItems.Add(new ShoppingCart
            {
                ShoppingItem = item,
                Quantity = quantity
            });
        }

        // Save the updated cart to the database
        ShoppingLocalDatabase.Instance.SaveCart(CartItems);
    }
}
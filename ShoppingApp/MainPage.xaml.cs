using ShoppingApp.Models;
using ShoppingApp.Services;
using System.Collections.ObjectModel;


namespace ShoppingApp
{
    public partial class MainPage : ContentPage
    {
        private ShoppingLocalDatabase _database;

        private CustomerProfile _currentProfile;
        public CustomerProfile CurrentProfile
        {
            get { return _currentProfile; }
            set { 
                _currentProfile = value; 
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _database = new ShoppingLocalDatabase();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadData();
        }

        private void LoadData()
        {
            CustomerProfile customerProfile = _database.GetCustumerProfileById(1);
            CurrentProfile = customerProfile;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _database.UpdateCustomerPrile(CurrentProfile);

            if (CurrentProfile != null)
            {
                 DisplayAlert("Successfully", "Profile Saved.", "OK");
            }

            
        }
        

        

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineTutorial.Models;

namespace VendingMachineTutorial.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        //Model the product view model represents
        private VendingItem _model;
        //Maximum number of items allowed in this view model
        private const int _maxQuantity = 10;
        //Current quantity in the view model
        private int _quantity;

        public int Id
        {
            get
            {
                return _model.Id;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            private set
            {
                _quantity = value;
                OnPropertyChanged("OutOfStockMessage");
                OnPropertyChanged("InventoryDisplay");
                OnPropertyChanged("Quantity");
            }
        }

        //Formatted display message of this product quantity
        //Ex: "Regular Soda: 7"
        public string InventoryDisplay
        {
            get
            {
                return _model.Name + ": " + _quantity;
            }
        }

        //Return a copy of this model values
        public VendingItem Information
        {
            get
            {
                return _model;
            }
        }

        //Determine if we need to display an "Out of stock" message
        public Visibility OutOfStockMessage
        {
            get
            {
                if (Quantity > 0)
                    return Visibility.Hidden;

                return Visibility.Visible;
            }
        }

        public ProductViewModel(int id, string name, double price)
        {
            _model = new VendingItem(id, name, price);
            Quantity = 0;
        }

        public int Refill()
        {
            var amount = _maxQuantity - Quantity;
            Quantity += amount;
            return amount;
        }

        public int Empty()
        {
            var amount = Quantity;
            Quantity = 0;
            return amount;
        }

        public bool Dispense()
        {
            if(Quantity > 0)
            {
                Quantity--;
                return true;
            }

            return false;
        }
    }
}

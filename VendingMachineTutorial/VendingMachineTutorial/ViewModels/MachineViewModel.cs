using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTutorial.ViewModels
{
    public class MachineViewModel : ObservableObject
    {
        public ObservableCollection<ProductViewModel> Items { get; private set; }
        public PaymentViewModel Bank { get; private set; }

        public MachineViewModel()
        {
            Bank = new PaymentViewModel();
            Items = new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel(1, "Regular", 0.50),
                new ProductViewModel(2, "Diet", 0.50),
                new ProductViewModel(3, "Orange", 0.75),
                new ProductViewModel(4, "Grape", 0.75),
            };
        }

        public void Purchase(object item)
        {
            var requestedItem = item as ProductViewModel;
            Bank.SelectedPrice(requestedItem.Information.Price);

            if(Bank.Confirm())
            {
                if(requestedItem.Dispense())
                {
                    Bank.Pay();
                    Console.WriteLine("Enjoy your beverage!");
                }
            }
        }

        public void InsertChange(double value)
        {
            Bank.Insert(value);
        }

        public void CollectPayments()
        {
            Bank.Collect();
        }

        public void Refill()
        {
            foreach(var i in Items)
            {
                i.Refill();
            }
            Console.WriteLine("Machine has been refilled!");
        }

        public void Empty()
        {
            foreach (var i in Items)
            {
                i.Empty();
            }
            Console.WriteLine("Machine has been cleared!");
        }
    }
}

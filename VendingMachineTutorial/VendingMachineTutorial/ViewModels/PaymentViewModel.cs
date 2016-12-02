using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTutorial.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        //Customer information
        private double _total;
        private double _inserted;
        private double _change;

        //Machine information
        private double _bankTotal;

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        public double Inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = value;
                OnPropertyChanged("Inserted");
            }
        }

        public double Change
        {
            get
            {
                return _change;
            }
            set
            {
                _change = value;
                OnPropertyChanged("Change");
            }
        }

        public double BankTotal
        {
            get
            {
                return _bankTotal;
            }
            set
            {
                _bankTotal = value;
                OnPropertyChanged("BankTotal");
            }
        }

        public PaymentViewModel()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }

        //Insert monetary value
        public void Insert(double value)
        {
            Inserted += value;
        }

        //Set the total the requested item costs
        public void SelectedPrice(double value)
        {
            Total = value;
        }

        //Confirm the payment can be made
        public bool Confirm()
        {
            if (Inserted >= Total)
                return true;

            return false;
        }

        //Finalize payment
        public void Pay()
        {
            Change = Total - Inserted;
            BankTotal += Total;
            Inserted = 0;
            Total = 0;
        }

        public void Collect()
        {
            Console.WriteLine("Collected Payments: $" + BankTotal);
            BankTotal = 0;
        }

    }
}

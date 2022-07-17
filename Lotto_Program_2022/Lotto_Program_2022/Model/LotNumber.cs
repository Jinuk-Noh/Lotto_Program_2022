using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lotto_Program_2022.Model
{
    public class LotNumber : Notifier
    {
        private int? _Number;
        public int? Number
        { 
            get { return _Number; }
            set { _Number = value; OnPropertyChanged("Number"); }
        }

        private NumberStatus _RightStatus;
        public NumberStatus RightStatus
        {
            get { return _RightStatus; }
            set { _RightStatus = value; OnPropertyChanged("RightStatus"); }
        }

        public LotNumber(int lotNumber)
        {
            this.Number = lotNumber;
            this.RightStatus = NumberStatus.Nothing;

            LotNumbers.SetNumber(this);
        }

        public LotNumber()
        {
            LotNumbers.SetNumber(this);
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
    
    public enum NumberStatus
    {
        Nothing = 0,
        Right = 1,
        Fail = 2
    }

    public class LotNumbers
    {
        static ObservableCollection<LotNumber> numbers = new ObservableCollection<LotNumber>();
        public static ObservableCollection<LotNumber> GetAllNumbers()
        {
            return numbers;
        }

        public static ObservableCollection<LotNumber> SetNumber(LotNumber lot)
        {
            if (lot.Number == null || lot.Number > 45)
            {
                lot.Number = null;
            }

            if (!numbers.Contains(lot))
            {
                numbers.Add(lot);
            }

            return numbers;
        }
    }

    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

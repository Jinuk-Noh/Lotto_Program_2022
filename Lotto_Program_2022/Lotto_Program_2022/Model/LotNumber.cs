using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto_Program_2022.Model
{
    public class LotNumber: Notifier
    {
        private int _Number;
        public int Number 
        {   get { return _Number; }
            set {_Number = value; OnPropertyChanged("Number"); } 
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
        ObservableCollection<LotNumber> numbers = new ObservableCollection<LotNumber>();
        public ObservableCollection<LotNumber> GetAllNumbers()
        {
            for (int i = 1; i < 46; i++)
            {
                numbers.Add(new LotNumber(i));
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

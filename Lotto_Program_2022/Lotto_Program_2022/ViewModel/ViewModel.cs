using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotto_Program_2022.Model;

namespace Lotto_Program_2022.ViewModel
{
    public class ViewModel :Notifier
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

}

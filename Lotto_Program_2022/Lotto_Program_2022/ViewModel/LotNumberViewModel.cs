using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lotto_Program_2022.Model;
using Lotto_Program_2022.ViewModel.Command;

namespace Lotto_Program_2022.ViewModel
{
    public class LotNumberViewModel
    {
        public DataRetrieveCommand DataRetrieveCommand { get;set;}

        private LotNumber model; 
        public LotNumber Model
        {
            get { return model; }
            set { model = value; }
        }

        public LotNumberViewModel()
        {
            DataRetrieveCommand = new DataRetrieveCommand(DataRetrieve);
            model = new LotNumber();
        }

        public void DataRetrieve()
        {
            foreach(var num in LotNumbers.GetAllNumbers())
            {
                MessageBox.Show(num.ToString());
            }
        }

    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lotto_Program_2022.Model;
using Lotto_Program_2022.ViewModel.Command;
using Newtonsoft.Json.Linq;

namespace Lotto_Program_2022.ViewModel
{
    public class LotNumberViewModel : Notifier
    {
        public DataRetrieveCommand DataRetrieveCommand { get;set;}

        private LotNumber model1; 
        public LotNumber Model1
        {
            get { return model1; }
            set { model1 = value; }
        }

        private LotNumber model2;
        public LotNumber Model2
        {
            get { return model2; }
            set { model2 = value; }
        }

        private LotNumber model3;
        public LotNumber Model3
        {
            get { return model3; }
            set { model3 = value; }
        }

        private LotNumber model4;
        public LotNumber Model4
        {
            get { return model4; }
            set { model4 = value; }
        }

        private LotNumber model5;
        public LotNumber Model5
        {
            get { return model5; }
            set { model5 = value; }
        }

        private LotNumber model6;
        public LotNumber Model6
        {
            get { return model6; }
            set { model6 = value; }
        }

        private LotNumber model7;
        public LotNumber Model7
        {
            get { return model7; }
            set { model7 = value; }
        }


        public LotNumberViewModel()
        {
            DataRetrieveCommand = new DataRetrieveCommand(DataRetrieve);
            model1 = new LotNumber();
            model2 = new LotNumber();
            model2 = new LotNumber();
            model3 = new LotNumber();
            model4 = new LotNumber();
            model5 = new LotNumber();
            model6 = new LotNumber();
            model7 = new LotNumber();

            lotNumbers = new Dictionary<string, LotNumber>();

            lotNumbers.Add("drwtNo1", new LotNumber());
            lotNumbers.Add("drwtNo2", new LotNumber());
            lotNumbers.Add("drwtNo3", new LotNumber());
            lotNumbers.Add("drwtNo4", new LotNumber());
            lotNumbers.Add("drwtNo5", new LotNumber());
            lotNumbers.Add("drwtNo6", new LotNumber());
            lotNumbers.Add("bnusNo", new LotNumber());
        }

        private Dictionary<string, LotNumber> lotNumbers;

        public LotNumber RightNumber1
        {
            get 
            {
                return lotNumbers["drwtNo1"];
            }

            set
            {
                lotNumbers["drwtNo1"] = value;
            }
        }

        public LotNumber RightNumber2
        {
            get
            {
                return lotNumbers["drwtNo2"];
            }

            set
            {
                lotNumbers["drwtNo2"] = value;
            }
        }

        public LotNumber RightNumber3
        {
            get
            {
                return lotNumbers["drwtNo3"];
            }

            set
            {
                lotNumbers["drwtNo3"] = value;
            }
        }

        public LotNumber RightNumber4
        {
            get
            {
                return lotNumbers["drwtNo4"];
            }

            set
            {
                lotNumbers["drwtNo4"] = value;
            }
        }

        public LotNumber RightNumber5
        {
            get
            {
                return lotNumbers["drwtNo5"];
            }

            set
            {
                lotNumbers["drwtNo5"] = value;
            }
        }

        public LotNumber RightNumber6
        {
            get
            {
                return lotNumbers["drwtNo6"];
            }

            set
            {
                lotNumbers["drwtNo6"] = value;
            }
        }

        public LotNumber RightNumber7
        {
            get
            {
                return lotNumbers["bnusNo"];
            }

            set
            {
                lotNumbers["bnusNo"] = value;
            }
        }

        public string drwNo
        {
            get;
            set;
        }

        public void DataRetrieve(string input)
        {
            JObject jObject = GetJObject(input);

            foreach (var obj in jObject)
            {
                if (obj.Key.ToString().Contains("drwtNo") || obj.Key.ToString().Contains("bnusNo"))
                {
                    lotNumbers[obj.Key.ToString()].Number = int.Parse(obj.Value.ToString());
                }
            }

            foreach (var lot in LotNumbers.GetAllNumbers())
            {
                if(lotNumbers.Where(x=> x.Value.ToString() == lot.ToString()).Count() > 0)
                {
                    lot.RightStatus = NumberStatus.Right;
                }
                else
                {
                    lot.RightStatus = NumberStatus.Fail;
                }
            }
        }

        private JObject GetJObject(string input)
        {
            string url = @"https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo=";

            WebRequest request = WebRequest.Create(url + input);
            request.Method = "GET";
            request.ContentType = "application/json";

            using(WebResponse response = request.GetResponse())
            {
                using(Stream stream = response.GetResponseStream())
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        string data = reader.ReadToEnd();

                        return JObject.Parse(data);
                    }
                }
            }
        }
    }
}

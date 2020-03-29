using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.VIewModels
{
    public class ResultViewModel
    {
        public ResultViewModel(int flag, string information, IEnumerable<object> dataSet = null)
        {
            Flag = flag;
            Information = information;
            DataSet = dataSet;
        }

        public int Flag { get; }
        public string Information { get; }
        public IEnumerable<object> DataSet { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnesCenter.VIewModels
{
    public class ResultViewModel
    {
        public ResultViewModel(int flag, string information, IEnumerable<object> dataSet = null, object additionalInfo = null)
        {
            Flag = flag;
            Information = information;
            DataSet = dataSet;
            AdditionalInfo = additionalInfo;
        }

        public int Flag { get; }
        public string Information { get; }
        public IEnumerable<object> DataSet { get; }
        public object AdditionalInfo { get; }
    }
}

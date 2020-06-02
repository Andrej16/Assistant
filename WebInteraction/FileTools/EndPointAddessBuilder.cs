using InvalidPassports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidPassports
{
    public class EndPointAddessBuilder : IAddressBuilder
    {
        private string _baseAddress;

        public EndPointAddessBuilder(string baseAddress)
        {
            _baseAddress = baseAddress;
        }
        public string Build()
        {
            DateTime current = DateTime.Now.AddDays(-1);
            string postFix = current.ToString("ddMMyyyy") + ".csv";
            return postFix;
        }
    }
}

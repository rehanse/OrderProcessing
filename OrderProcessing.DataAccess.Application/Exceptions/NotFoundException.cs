using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.DataAccess.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, string messgae, object key) : base($"{name}:{messgae}({key}))")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersLinkAssignment.Aplication.Exeptions
{
    public class ApiExeption : Exception
    {
        public ApiExeption() : base()
        {
        }

        public ApiExeption(string message) : base(message)
        {
        }

        public ApiExeption(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture,
            message, args))
        {
        }
    }
}

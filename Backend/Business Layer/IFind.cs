using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{ 
    internal interface IFind<TResult>
    {
        TResult Find(object? data);
    }
}

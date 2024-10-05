using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Finder
    {

        public static TDTO Find<TDTO, T>(T data, Enum findBy) 
        {
            // Get the type of the DTO (like CustomerDTO, CakeDTO)
            var entityType = typeof(TDTO); 

            // Construct the class name based on the entity type (clsCustomerData)
            string className = $"DataAccessLayer.cls{entityType.Name.Replace("DTO", "Data")}, DataAccessLayer";

            // Construct the method name based on the enum value (GetCustomerById)
            string methodName =  $"Get{entityType.Name.Replace("DTO", "")}By{findBy}";

            // Get the class type using reflection
            // Find the method using reflection
            var method = Type.GetType(className).GetMethod(methodName);


            // Invoke the method and return the result, casting it to the correct DTO type
            var result = method.Invoke(null, new object[] { data });
            return (TDTO)result;
        }
    }

}

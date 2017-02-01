using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes
{
    static class RecipeExceptions
    {
        public static string AnalyzeException(Exception ex)
        {
            string result;
            if (ex.Message.Contains("Data at the root level is invalid"))
            {
                result = "Invalid Data";
            }
            else if (ex.Message.Contains("Input string was not in a correct format"))
            {
                result = "You entered invlaid characters";
            }
            else if (ex.Message.Contains("Not a valid selection!"))
            {
                result = "You entered a selection that does not exist! try again";
            }
            else if (ex.Message.Contains("Value was either too large or too small for an "))
            {
                result = "Value is out of range";
            }
            else
            {
                result = "An exception was thrown, but I dont know why!";
            }
            return result;
                
        }
    }
}

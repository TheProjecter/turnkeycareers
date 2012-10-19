using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace careers.Utilities
{
    public class ValidationUtility
    {
        public static String regExp = "";


        public static bool isNotNull(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool isNotBlank(String value)
        {
            if (value == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool isNotNullOrBlank(String value)
        {
            if (isNotNull(value) && isNotBlank(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean IsNumeric(string stringToTest) //Code Reference: http://geekswithblogs.net/TJ/archive/2011/03/29/c-isnumeric.aspx
        {
            int result;
            return int.TryParse(stringToTest, out result);
        }

        public static bool IsDouble(string text)//Code Reference: http://www.inforbiro.com/blog-eng/csharp-check-if-string-is-double/
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }

        public static bool IsDateTime(string value)
        {
            try
            {
                DateTime date = DateTime.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
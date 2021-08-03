using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebApplication.CustomValidation
{
    public class LessThan:ValidationAttribute
    {
        public LessThan() : base ("Date should be less that or equal to current date")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return true;
            else
                return false;
        }

    }
}

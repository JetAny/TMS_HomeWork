using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageDB.Validation
{
    public class FuelValidationAttribute : ValidationAttribute
    {
        //массив для хранения видов топлива
        string[] _fuels;

        public FuelValidationAttribute(string[] fuels)
        {
            _fuels = fuels;
        }
        public override bool IsValid(object value)
        {
            if (value != null && _fuels.Contains(value.ToString()))
            {
                return true;
            }
                

            return false;
        }
    }
}

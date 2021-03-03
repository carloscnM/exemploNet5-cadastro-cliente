using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models.ModelsValidations
{
    public class CPFValid : ValidationAttribute
    {
        public CPFValid(){}
       
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) 
                return true;

            return Utils.CPF.IsValid(value.ToString());
        }

    }
}
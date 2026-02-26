using Dapper;
using Domain.Models;

namespace Framework.Extensions
{
    public static class SmartPhoneExtension
    {
        public static DynamicParameters ToSmartPhoneDynamicParameters(this SmartPhoneModel smartPhone)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SmartPhoneId", smartPhone.SmartPhoneId);
            parameters.Add("@Brand", smartPhone.Brand);
            parameters.Add("@Model", smartPhone.Model);
            parameters.Add("@Price", smartPhone.Price);
            parameters.Add("@Storage", smartPhone.Storage);
            return parameters;
        }

        public static DynamicParameters ToCreateSmartPhoneDynamicParameters(this SmartPhoneModel smartPhone)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Brand", smartPhone.Brand);
            parameters.Add("@Model", smartPhone.Model);
            parameters.Add("@Price", smartPhone.Price);
            parameters.Add("@Storage", smartPhone.Storage);
            return parameters;
        }

        public static DynamicParameters ToDeleteSmartPhoneDynamicParameters(int smartPhoneId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SmartPhoneId", smartPhoneId);
            return parameters;
        }
    }
}

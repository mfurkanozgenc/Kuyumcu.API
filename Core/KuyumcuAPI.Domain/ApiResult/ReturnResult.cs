using KuyumcuAPI.Domain.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Domain.ApiResult
{
    public class ReturnResult
    {
        public KuyumcuSystemResult<string> ErrorResponse(string errorMessage)
        {
            return new KuyumcuSystemResult<string>
            {
                ErrorCode = Result.Error,
                ErrorMessage = "Hata",
                Value = errorMessage
            };
        }

        public KuyumcuSystemResult<string> SuccessResponse(string successMessage)
        {
            return new KuyumcuSystemResult<string>
            {
                ErrorCode = Result.Successful,
                ErrorMessage = "Başarılı",
                Value = successMessage
            };
        }
    }
}

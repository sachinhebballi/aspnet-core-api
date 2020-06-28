using aspnet_core_api.Models;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_core_api.Extensions
{
    public static class FluentValidationExtensions
    {
        public static List<FieldLevelError> GetFieldLevelErrors(this ValidationResult validationResult)
        {
            var errorsList = new List<FieldLevelError>();

            var errorMessages = validationResult.Errors;
            foreach (var errorMessage in errorMessages)
            {
                errorsList.Add(new FieldLevelError
                {
                    Field = errorMessage.PropertyName,
                    Code = errorMessage.ErrorCode,
                    Message = errorMessage.ErrorMessage
                });
            }

            return errorsList;
        }

        public static List<string> GetErrorMessages(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
    }
}

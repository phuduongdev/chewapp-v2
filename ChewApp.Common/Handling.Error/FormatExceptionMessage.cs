using System;
using System.Data.Entity.Validation;

namespace ChewApp.Common.Handling.Error {

    public class FormatExceptionMessage {

        public static string FormatDbEntityValidationExceptionErrorMessage(DbEntityValidationException dbEx) {
            var errorMessage = "";
            foreach(var validationErrors in dbEx.EntityValidationErrors) {
                foreach(var validationError in validationErrors.ValidationErrors)
                    errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName,
                        validationError.ErrorMessage)
                        + Environment.NewLine;
            }
            return errorMessage;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutcomeOf
{
    public class Error
    {
        public string? Code { get; init; }
        public string Massage { get; init; } = string.Empty;
        public ErrorType Type { get ; init; }


        private Error(string code, string description, ErrorType failure)
        {
            Code = code;
            Massage = description;
            Type = failure;
        }
        #region factory methods
        public static Error Failure(string code = "General.Failure", string description = "A failure has occurred.")
        {
            return new Error(code, description, ErrorType.Failure);
        }
        public static Error Conflict(string code = "General.Conflict", string description = "A conflict error has occurred.")
        {
            return new Error(code, description, ErrorType.Conflict);
        }
        public static Error NotFound(string code = "General.NotFound", string description = "A 'Not Found' error has occurred.")
        {
            return new Error(code, description, ErrorType.NotFound);
        }
        public static Error Forbidden(string code = "General.Forbidden", string description = "A 'Forbidden' error has occurred.")
        {
            return new Error(code, description, ErrorType.Forbidden);
        }
        public static Error Validation(string code = "General.Validation", string description = "A validation error has occurred.")
        {
            return new Error(code, description, ErrorType.Validation);
        }
        #endregion


        public override string ToString()
        {
            return $"{Type.ToString()}: {Code} - {Massage}";
        }

    }
}

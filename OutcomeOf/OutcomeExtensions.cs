using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutcomeOf
{
    public static class OutcomeExtensions
    {
        public static OutcomeOf<TValue> ToOutcomeOf<TValue>(this TValue value)
        {
            return OutcomeOf<TValue>.FromValue(value);
        }
        public static OutcomeOf<TValue> ToOutcomeOf<TValue>(this Error error)
        {
            return OutcomeOf<TValue>.FromError(error);
        }
    }


}

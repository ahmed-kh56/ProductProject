
namespace OutcomeOf
{

    public class OutcomeOf<TValue> : IOutcomeOf<TValue>, IOutcomeOf
    {
        public Error? Error { get; }
        public TValue? Value { get; }

        public bool IsSuccess => Error is null;
        public bool IsFailure => !IsSuccess;

        private OutcomeOf(TValue value)
        {
            Value = value;
        }

        private OutcomeOf(Error error)
        {
            Error = error;
        }

        public static OutcomeOf<TValue> FromValue(TValue value)
            => new OutcomeOf<TValue>(value);

        public static OutcomeOf<TValue> FromError(Error error)
            => new OutcomeOf<TValue>(error);


        public static implicit operator OutcomeOf<TValue>(TValue value)
            => new OutcomeOf<TValue>(value);

        public static implicit operator OutcomeOf<TValue>(Error error)
            => new OutcomeOf<TValue>(error);


        public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onValue, Func<Error,TNextValue> onError)
        {
            if (IsFailure)
            {
                return onError(Error);
            }

            return onValue(Value);
        }

    }
}




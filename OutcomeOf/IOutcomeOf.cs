namespace OutcomeOf
{
    public interface IOutcomeOf<TValue>
    {
        TValue? Value { get; }
        Error? Error { get; }
    }

    public interface IOutcomeOf
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
    }
}

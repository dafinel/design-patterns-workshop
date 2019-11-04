namespace ChainOfResponsability.Handlers
{
    public interface IStepHandler
    {
        IStepHandler NextHandler { get; }
        void SetNext(IStepHandler nextHandler);
        void Handle();
    }
}
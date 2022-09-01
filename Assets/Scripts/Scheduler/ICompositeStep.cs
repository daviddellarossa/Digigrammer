namespace Assets.Scripts.Scheduler
{
    public interface ICompositeStep : IBaseStep
    {
        System.Collections.Generic.List<IBaseStep> Steps { get;}
    }
}

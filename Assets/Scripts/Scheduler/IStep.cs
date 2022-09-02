using Assets.Scripts.Agents;

namespace Assets.Scripts.Scheduler
{
    interface IStep : IBaseStep
    {
        IAgent Agent { get; }

        IMask Mask { get; }

        float Amount { get; }

        float Duration { get; }
    }
}

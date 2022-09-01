using Assets.Scripts.Agents;

namespace Assets.Scripts.Scheduler
{
    interface IStep : IBaseStep
    {
        public AgentSO Agent { get; }

        public Mask Mask { get; }

        public float Amount { get; }

        public float Duration { get; }
    }
}

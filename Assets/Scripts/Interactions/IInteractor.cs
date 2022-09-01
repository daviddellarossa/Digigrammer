using Assets.Scripts.Agents;

namespace Assets.Scripts.Interactions
{
    public interface IInteractor<TAgent1, TAgent2>
        where TAgent1 : IAgent
        where TAgent2 : IAgent
    {
        TAgent1 Agent1 { get; }
        TAgent2 Agent2 { get; }

        void Interact();
    }
}

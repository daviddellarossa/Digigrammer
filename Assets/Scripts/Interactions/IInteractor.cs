using Assets.Scripts.Agents;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interactions
{
    interface IInteractor
    {
        List<AgentSO> InAgents { get; }

        List<AgentSO> OutAgents { get; }

        ComputeShader Shader { get; }

        void Interact();

        int GetId();

    }
}

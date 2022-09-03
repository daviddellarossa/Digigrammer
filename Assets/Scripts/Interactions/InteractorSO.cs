using Assets.Scripts.Agents;
using Assets.Scripts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interactions
{
    [CreateAssetMenu(menuName = "Digigrammer/Interactor", fileName = "New Interactor")]

    class InteractorSO : ScriptableObject , IInteractor
    {
        [Header("Configuration")]
        [SerializeField] private StaticObjectsSO StaticObjects;

        [Space]
        [Header("Shader")]
        [SerializeField] private ComputeShader shader;

        [Space]
        [Header("Agents")]
        [SerializeField] private List<AgentSO> inAgents;
        [SerializeField] private List<AgentSO> outAgents;

        public ComputeShader Shader => shader;

        public List<AgentSO> InAgents => inAgents;

        public List<AgentSO> OutAgents => outAgents;

        public void Interact()
        {
            var inAgentBuffersDict = this.StaticObjects.MessageBroker.Interaction.Send_RequestForMultiAgentBuffers(this, null, inAgents.Select(x => x.GetInstanceID()).ToArray());
            
            if(inAgentBuffersDict is null)
            {
                Debug.LogError("Returned object from Send_RequestForMultiAgentBuffers cannot be null");
            }

            var outAgentBuffersDict = this.StaticObjects.MessageBroker.Interaction.Send_RequestForMultiAgentBuffers(this, null, outAgents.Select(x => x.GetInstanceID()).ToArray());

            if (outAgentBuffersDict is null)
            {
                Debug.LogError("Returned object from Send_RequestForMultiAgentBuffers cannot be null");
            }

            foreach (var agent in inAgents)
            {
                int counter = 0;
                var agentBuffer = inAgentBuffersDict[agent.GetInstanceID()];

                this.Shader.SetTexture(0, $"in_{counter++}", agentBuffer.Buffer);
            }

            foreach (var agent in outAgents)
            {
                int counter = 0;
                var agentBuffer = outAgentBuffersDict[agent.GetInstanceID()];

                this.Shader.SetTexture(0, $"out_{counter++}", agentBuffer.Buffer);
            }

            var digigramSize = this.StaticObjects.MessageBroker.Digigram.Send_RequestForSize(this, null);
            if(digigramSize is null)
            {
                Debug.LogError("Digigram size cannot be null");
            }

            var dispatchSize = new Vector3Int(Mathf.CeilToInt((digigramSize.Value.x) / 8f), Mathf.CeilToInt((digigramSize.Value.y) / 8f), 1);

            this.shader.Dispatch(0, dispatchSize.x, dispatchSize.y, dispatchSize.z);

            // TODO: read the textures back
        }

        public int GetId()
        {
            int id = 0;
            InAgents.ForEach(x => id ^= x.GetInstanceID());
            return id;
        }
    }
}

using Assets.Scripts.Agents;
using Assets.Scripts.Common;
using Assets.Scripts.Interactions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Digigram
{

    [CreateAssetMenu(menuName = "Digigrammer/Digigram", fileName = "Digigram")]
    class DigigramSO : ScriptableObject, IDigigram
    {

        [Space]
        [Header("Configuration")]
        [SerializeField] private StaticObjectsSO staticObjects;
        [Space]
        [SerializeField] private Vector2Int textureSize = new(1080, 1080);
        [SerializeField] private int bitsPerChannel = 16;
        [SerializeField] private readonly int channels = 3;

        [Header("Shaders")]
        [SerializeField] private ComputeShader addAgentBuffer;

        private Dictionary<int, AgentBuffer> agents = new();

        private Dictionary<int, IInteractor> interactors = new();

        public StaticObjectsSO StaticObjects  => staticObjects;

        public RenderTexture Texture { get; set; }

        public Vector2Int TextureSize  => textureSize;

        public  int BitsPerChannel => bitsPerChannel;

        public int Channels => channels;

        void Awake()
        {
            RegisterMessageHandlers();
        }
        void OnDestroy()
        {
            UnRegisterMessageHandlers();
        }

        private void RegisterMessageHandlers()
        {
            if(this.StaticObjects is null)
            {
                Debug.LogError("StaticObjects cannot be null in DigigramSO");
            }

            this.StaticObjects.MessageBroker.Digigram.RequestForSize += Digigram_RequestForSize_MessageHandler;
            this.StaticObjects.MessageBroker.Interaction.RequestForMultiAgentBuffers += Interaction_RequestForMultiAgentBuffers_MessageHandler;
            this.StaticObjects.MessageBroker.Interaction.RequestForAgentBuffer += Interaction_RequestForAgentBuffer_MessageHandler;
        }

        private AgentBuffer Interaction_RequestForAgentBuffer_MessageHandler(object sender, object target, int agentId)
        {
            AgentBuffer agentBuffer = null;
            this.agents.TryGetValue(agentId, out agentBuffer);
            return agentBuffer;
        }

        private Dictionary<int, AgentBuffer> Interaction_RequestForMultiAgentBuffers_MessageHandler(object sender, object target, int[] agentIds)
        {
            var dictionary = new Dictionary<int, AgentBuffer>();
            foreach(var id in agentIds.Distinct())
            {
                AgentBuffer agentBuffer = null;
                this.agents.TryGetValue(id, out agentBuffer);
                if(agentBuffer is null)
                {
                    Debug.LogWarning($"AgentBuffer with id {id} not found in dictionary");
                    continue;
                }

                dictionary.Add(id, agentBuffer);
            }

            return dictionary;
        }

        private void UnRegisterMessageHandlers()
        {
            this.StaticObjects.MessageBroker.Digigram.RequestForSize -= Digigram_RequestForSize_MessageHandler;
            this.StaticObjects.MessageBroker.Interaction.RequestForMultiAgentBuffers -= Interaction_RequestForMultiAgentBuffers_MessageHandler;
            this.StaticObjects.MessageBroker.Interaction.RequestForAgentBuffer -= Interaction_RequestForAgentBuffer_MessageHandler;

        }

        private Vector2Int? Digigram_RequestForSize_MessageHandler(object arg1, object arg2)
        {
            return this.textureSize;
        }

        public void InitializeTexture()
        {
            Texture = new RenderTexture(TextureSize.x, TextureSize.y, BitsPerChannel * Channels);

            StaticObjects.MessageBroker.Render.Send_TextureUpdated(this, null, Texture);
        }

        public void AddAgent(AgentSO agent, Texture2D agentBuffer = null)
        {
            if (agents.ContainsKey(agent.GetInstanceID()))
            {
                if(agentBuffer is null)
                {
                    return;
                }
                else
                {
                    var currentAgent = agents[agent.GetInstanceID()];
                    this.addAgentBuffer.SetTexture(0, "texture1", currentAgent.Buffer);
                    this.addAgentBuffer.SetTexture(0, "texture2", agentBuffer);

                    this.addAgentBuffer.Dispatch(0, 8, 8, 8);

                    // TODO: READ THE TEXTURE BACK
                }

            }

            agents.Add(agent.GetInstanceID(), new AgentBuffer(agent, this.textureSize.x, this.textureSize.y));
        }

        public void AddInteractor(InteractorSO interactor)
        {
            var interactorId = interactor.GetId();
            if (interactors.ContainsKey(interactorId))
            {
                Debug.Log($"Interactor with id {interactorId} already in dictionary");
                return;
            }
            interactors.Add(interactorId, interactor);
        }
    }
}

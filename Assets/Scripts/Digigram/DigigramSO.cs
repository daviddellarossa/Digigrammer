using Assets.Scripts.Agents;
using Assets.Scripts.Common;
using Assets.Scripts.Interactions;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Digigram
{
    [CreateAssetMenu(menuName = "Digigrammer/Digigram", fileName = "Digigram")]

    class DigigramSO : ScriptableObject, IDigigram
    {
        [Space]
        [SerializeField] private Vector2Int textureSize = new(1080, 1080);
        [SerializeField] private int bitsPerChannel = 16;
        [SerializeField] private readonly int channels = 3;

        private List<IAgent> agents = new();

        private Dictionary<int, IInteractor> interactors = new();

        public StaticObjectsSO StaticObjects { get; set; }

        public RenderTexture Texture { get; set; }

        public Vector2Int TextureSize  => textureSize;

        public  int BitsPerChannel => bitsPerChannel;

        public int Channels => channels;


        public void InitializeTexture()
        {
            Texture = new RenderTexture(TextureSize.x, TextureSize.y, BitsPerChannel * Channels);

            StaticObjects.MessageBroker.Render.Send_TextureUpdated(this, null, Texture);
        }

        public void AddAgent(AgentSO agent)
        {
            if (agents.Contains(agent))
            {
                return;
            }

            agents.Add(agent);
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
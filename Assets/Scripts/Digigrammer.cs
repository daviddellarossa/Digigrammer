using Assets.Scripts.Scheduler;
using Digigrammer.Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Digigrammer.Assets.Scripts
{
    [RequireComponent(typeof(Canvas))]
    public class Digigrammer : MonoBehaviour
    {
        [Header("Configuration")]
        [Space]
        [SerializeField] private StaticObjectsSO staticObjects;

        [Space]
        [SerializeField] private DigigramSO digigram;

        private RawImage rawImage;

        private Scheduler scheduler;


        private void Awake()
        {
            this.staticObjects.MessageBroker.App.Send_Startup(this, null);

            this.scheduler = new Scheduler();

            this.rawImage = GetComponentInChildren<RawImage>();

            if (this.rawImage == null)
            {
                Debug.LogError("RawImage is not found");
            }
        }

        private void Start()
        {
            this.digigram.InitializeTexture();
            //Graphics.Blit(mask, digigram.Texture);

            this.rawImage.texture = this.digigram.Texture;
        }

        private void OnDestroy()
        {
            this.staticObjects.MessageBroker.App.Send_Shutdown(this, null);
        }
    }
}

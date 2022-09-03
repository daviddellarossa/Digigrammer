using Assets.Scripts.Digigram;
using Assets.Scripts.Common;
using Assets.Scripts.Scheduler;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Digigrammer
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

        private IScheduler scheduler;


        private void Awake()
        {
            staticObjects.MessageBroker.App.Send_Startup(this, null);

            scheduler = new Scheduler.Scheduler();

            rawImage = GetComponentInChildren<RawImage>();

            if (rawImage == null)
            {
                Debug.LogError("RawImage is not found");
            }
        }

        private void Start()
        {
            digigram.InitializeTexture();
            //Graphics.Blit(mask, digigram.Texture);

            rawImage.texture = digigram.Texture;
        }

        private void OnDestroy()
        {
            staticObjects.MessageBroker.App.Send_Shutdown(this, null);
        }
    }
}

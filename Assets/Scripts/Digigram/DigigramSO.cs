using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Digigram
{
    [CreateAssetMenu(menuName = "Digigrammer/Digigram", fileName = "Digigram")]

    class DigigramSO : ScriptableObject
    {
        [HideInInspector] public StaticObjectsSO StaticObjects;

        [HideInInspector] public RenderTexture Texture;

        [Space]
        public Vector2Int TextureSize = new(1080, 1080);

        public int BitsPerChannel = 16;

        public readonly int Channels = 3;

        public void InitializeTexture()
        {
            Texture = new RenderTexture(TextureSize.x, TextureSize.y, BitsPerChannel * Channels);

            StaticObjects.MessageBroker.Render.Send_TextureUpdated(this, null, Texture);
        }
    }
}
using Digigrammer.Assets.Scripts.Common;
using UnityEngine;

[CreateAssetMenu(menuName = "Digigrammer/Digigram", fileName = "Digigram")]

class DigigramSO : ScriptableObject
{
    [HideInInspector] public StaticObjectsSO staticObjects;

    [HideInInspector] public RenderTexture Texture;

    [Space]
    public Vector2Int TextureSize = new (1080, 1080);

    public int BitsPerChannel = 16;

    public readonly int Channels = 3;

    public void InitializeTexture()
    {
        this.Texture = new RenderTexture(this.TextureSize.x, this.TextureSize.y, this.BitsPerChannel * Channels);

        this.staticObjects.MessageBroker.Render.Send_TextureUpdated(this, null, this.Texture);
    }
}

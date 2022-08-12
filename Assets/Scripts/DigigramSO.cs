using Assets.Scripts.MessageBroker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Digigrammer/Digigram", fileName = "Digigram")]

public class DigigramSO : ScriptableObject
{
    [SerializeField] private Messenger messenger;

    [HideInInspector]
    public RenderTexture Texture;

    public Vector2Int TextureSize = new (1080, 1080);

    public int BitsPerChannel = 16;

    public readonly int Channels = 3;

    public void InitializeTexture()
    {
        this.Texture = new RenderTexture(this.TextureSize.x, this.TextureSize.y, this.BitsPerChannel * Channels);
    }
}

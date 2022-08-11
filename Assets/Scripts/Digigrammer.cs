using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Digigrammer : MonoBehaviour
{
    [SerializeField] private ComputeShader computeShader;

    [SerializeField] private Texture2D mask;

    [SerializeField] private DigigramSO digigram;
    private RawImage rawImage;

    public void ExecuteComputeShader(){
        computeShader.SetTexture(0, "texture", digigram.Texture);
        computeShader.SetTexture(0, "mask", mask);

        var dispatchSize = new Vector3Int(Mathf.CeilToInt((digigram.Texture.width) / 8f), Mathf.CeilToInt((digigram.Texture.height) / 8f), 1);

        computeShader.Dispatch(0, dispatchSize.x, dispatchSize.y, dispatchSize.z);
    }

    private void Awake() 
    {
        this.rawImage = GetComponentInChildren<RawImage>();

        if(this.rawImage == null){
            Debug.LogError("RawImage is not found");
        }
    }

    private void Start() 
    {
        this.digigram.InitializeTexture();
        Graphics.Blit(mask, digigram.Texture);

        this.rawImage.texture = this.digigram.Texture;

    }
}

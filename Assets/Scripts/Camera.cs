using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public ComputeShader digigramCS;

    public RenderTexture outputTexture;

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        outputTexture = new RenderTexture(1920, 1080, 48);
        outputTexture.enableRandomWrite = true;
        outputTexture.Create();

        digigramCS.SetTexture(0, "Result", outputTexture);
        digigramCS.Dispatch(0, outputTexture.width / 8, outputTexture.height / 8, 1);

        Graphics.Blit(outputTexture, dst);
    }
}
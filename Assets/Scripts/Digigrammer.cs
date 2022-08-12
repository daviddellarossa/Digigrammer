using Assets.Scripts.Agents.Agent1;
using Assets.Scripts.MessageBroker;
using Assets.Scripts.Scheduler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Digigrammer : MonoBehaviour
{
    [SerializeField] private DigigramSO digigram;
    [SerializeField] private Messenger messenger;

    private RawImage rawImage;

    private Scheduler scheduler;


    private void Awake() 
    {
        this.scheduler = new Scheduler();

        this.rawImage = GetComponentInChildren<RawImage>();

        if(this.rawImage == null){
            Debug.LogError("RawImage is not found");
        }
    }

    private void Start() 
    {
        this.digigram.InitializeTexture();
        //Graphics.Blit(mask, digigram.Texture);

        this.rawImage.texture = this.digigram.Texture;
    }
}

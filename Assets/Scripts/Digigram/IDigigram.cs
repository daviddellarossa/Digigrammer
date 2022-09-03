using Assets.Scripts.Agents;
using Assets.Scripts.Common;
using Assets.Scripts.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Digigram
{
    interface IDigigram
    {
        StaticObjectsSO StaticObjects { get; set; }

        RenderTexture Texture { get; set; }

        Vector2Int TextureSize { get; }

        int BitsPerChannel { get; }

        int Channels { get; }

        void InitializeTexture();

        void AddAgent(AgentSO agent);

        void AddInteractor(InteractorSO interactor);

    }
}

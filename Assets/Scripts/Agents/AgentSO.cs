using Assets.Scripts.Digigram;
using Assets.Scripts.Masks;
using System;
using UnityEngine;

namespace Assets.Scripts.Agents
{
    [CreateAssetMenu(menuName = "Digigrammer/Agent", fileName = "New Agent")]
    class AgentSO : ScriptableObject, IAgent
    {
        [SerializeField] private ComputeShader shader;

        public ComputeShader Shader => shader;

        public void ExecuteShader(IDigigram digigram, IMask mask)
        {
            this.shader.SetTexture(0, "texture", digigram.Texture);
            this.shader.SetTexture(0, "mask", mask.Texture);

            var dispatchSize = new Vector3Int(Mathf.CeilToInt((digigram.Texture.width) / 8f), Mathf.CeilToInt((digigram.Texture.height) / 8f), 1);

            this.shader.Dispatch(0, dispatchSize.x, dispatchSize.y, dispatchSize.z);
        }
    }
}

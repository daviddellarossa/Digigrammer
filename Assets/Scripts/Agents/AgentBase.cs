using Assets.Scripts.Scheduler;
using System;
using UnityEngine;

namespace Assets.Scripts.Agents
{
    [CreateAssetMenu(menuName = "Digigrammer/Agent", fileName = "New Agent")]
    public class AgentSO : ScriptableObject
    {
        [SerializeField] private AgentSettings settings;
        [SerializeField] private ComputeShader shader;

        public void ExecuteShader(DigigramSO digigram, Mask mask)
        {
            this.shader.SetTexture(0, "texture", digigram.Texture);
            this.shader.SetTexture(0, "mask", mask.Texture);

            var dispatchSize = new Vector3Int(Mathf.CeilToInt((digigram.Texture.width) / 8f), Mathf.CeilToInt((digigram.Texture.height) / 8f), 1);

            this.shader.Dispatch(0, dispatchSize.x, dispatchSize.y, dispatchSize.z);
        }
    }
}

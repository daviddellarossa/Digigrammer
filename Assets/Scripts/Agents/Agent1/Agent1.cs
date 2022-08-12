using System;
using UnityEngine;

namespace Assets.Scripts.Agents.Agent1
{
    [Serializable]
    public class Agent1 : IAgent
    {
        [SerializeField] private AgentSettings _settings;
        [SerializeField] private ComputeShader _shader;

        [HideInInspector]
        public AgentSettings Settings => throw new System.NotImplementedException();
        [HideInInspector]
        public ComputeShader Shader => throw new System.NotImplementedException();
    }
}

using System;
using UnityEngine;

namespace Assets.Scripts.Agents
{
    public interface IAgent
    {
        public AgentSettings Settings { get; }

        public ComputeShader Shader { get; }
    }
}
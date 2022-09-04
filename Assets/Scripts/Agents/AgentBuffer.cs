using UnityEngine;

namespace Assets.Scripts.Agents
{
    class AgentBuffer
    {
        public AgentSO Agent { get; set; }
        public Texture2D Buffer { get; set; }

        public AgentBuffer(AgentSO agent, int width, int height)
        {
            Agent = agent;
            Buffer = new Texture2D(width, height);
        }

    }
}
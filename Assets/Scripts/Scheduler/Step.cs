using Assets.Scripts.Agents;
using System;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    [Serializable]
    class Step
    {
        public AgentSO Agent;

        public Mask Mask;

        public float Amount;

        public float Duration;

        public void Execute()
        {
        }
    }
}

using Assets.Scripts.Agents;
using Assets.Scripts.Masks;
using System;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    [Serializable]
    class Step : IStep
    {
        public IAgent Agent { get; set; }

        public IMask Mask { get; set; }

        public float Amount { get; set; }

        public float Duration { get; set; }

        public void Execute()
        {
        }
    }
}

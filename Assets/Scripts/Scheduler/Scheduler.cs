using Assets.Scripts.MessageBroker;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    [Serializable]
    public class Scheduler
    {
        //[SerializeField] private MessageBroker.MessageBroker Messenger;

        public ScheduleSO schedule;

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

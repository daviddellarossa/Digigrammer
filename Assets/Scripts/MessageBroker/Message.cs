using System;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/Message", fileName = "New Message")]
    public class Message : ScriptableObject
    {
        public event Action<object, string, object> MessageEvent;

        public void SendMessage(object sender, string target, object payload)
        {
            MessageEvent?.Invoke(sender, target, payload);
        }
    }
}

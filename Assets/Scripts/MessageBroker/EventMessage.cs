using System;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/EventMessage", fileName = "New EventMessage")]
    public class EventMessage : ScriptableObject
    {
        public string Tooltip;
        public event Action<object, string, object> Message;

        public void SendMessage(object sender, string target, object payload)
        {
            Message?.Invoke(sender, target, payload);
        }
    }
}

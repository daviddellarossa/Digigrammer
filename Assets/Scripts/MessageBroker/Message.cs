using System;
using UnityEngine;
using static Assets.Scripts.MessageBroker.MessageSubscriber;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/Message", fileName = "New Message")]
    public class Message : ScriptableObject
    {
        public string Tooltip;
        public string Category = "Default";

        public RequestMessageEvent MessageEvent;

        public object SendMessage(MessagePayload payload)
        {
            Debug.Log("Invoking unityEvent");
            MessageEvent.Invoke(payload);
            return payload.response;
        }
    }
}

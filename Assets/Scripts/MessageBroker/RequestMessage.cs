using System;
using UnityEngine;
using static Assets.Scripts.MessageBroker.MessageSubscriber;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/RequestMessage", fileName = "New RequestMessage")]
    public class RequestMessage : ScriptableObject
    {
        public string Tooltip;

        public RequestMessageEvent MessageEvent;

        public object SendMessage(RequestMessagePayload payload)
        {
            Debug.Log("Invoking unityEvent");
            MessageEvent.Invoke(payload);
            return payload.response;
        }
    }
}

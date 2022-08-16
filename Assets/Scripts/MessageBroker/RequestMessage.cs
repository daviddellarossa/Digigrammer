using System;
using UnityEngine;
using static Assets.Scripts.MessageBroker.MessageSubscriber;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/RequestMessage", fileName = "New RequestMessage")]
    public class RequestMessage : ScriptableObject //, IRequestMessage
    {
        public string Tooltip;
        //public event Func<object, string, object, object> Message;
        public RequestMessageEvent MessageEvent;

        public object SendMessage()
        {
            object payload = "payload";
            var messagePayload = new RequestMessagePayload()
            {
                sender = this,
                target = "target",
                payload = payload,
            };
            Debug.Log("Invoking unityEvent");
            MessageEvent.Invoke(messagePayload);
            return messagePayload.response;
        }
    }
}

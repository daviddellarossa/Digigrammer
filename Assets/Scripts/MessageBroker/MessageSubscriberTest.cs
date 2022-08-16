using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    public class MessageSubscriberTest : MonoBehaviour
    {
        public void MessageHandler(RequestMessagePayload payload)
        {
            payload.response = "Response";
        }

    }
}

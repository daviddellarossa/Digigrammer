using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    public class MessageSubscriberTest : MonoBehaviour
    {
        public void Message1Handler(MessagePayload payload)
        {
            Debug.Log("Executing Message1Handler");
            payload.response = "Response 1";
        }

        public void Message2Handler(MessagePayload payload)
        {
            Debug.Log("Executing Message2Handler");
            payload.response = "Response 2";
        }
    }
}

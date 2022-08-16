using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/MessageBroker", fileName = "MessageBroker")]

    public class MessageBroker : ScriptableObject
    {
        public List<RequestMessage> messages;
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/MessageBroker", fileName = "MessageBroker")]

    public partial class MessageBroker_old : ScriptableObject
    {
        public List<RequestMessage> messages;
    }
}

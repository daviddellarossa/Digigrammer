using System;

namespace Assets.Scripts.MessageBroker
{
    [Serializable]
    public class MessagePayload
    {
        public object sender;
        public object target;
        public object payload;
        public object response;
    }
}

using System;

namespace Assets.Scripts.MessageBroker
{
    [Serializable]
    public class RequestMessagePayload
    {
        public object sender;
        public object target;
        public object payload;
        public object response;
    }
}

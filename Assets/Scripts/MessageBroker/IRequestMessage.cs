using System;

namespace Assets.Scripts.MessageBroker
{
    public interface IRequestMessage
    {
        event Func<object, string, object, object> Message;
    }
}

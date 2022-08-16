using UnityEditor;

namespace Assets.Scripts.MessageBroker
{
    public class MessageBrokerGen
    {
        [MenuItem("MessageBroker/Generate Message Broker")]
        static void GenerateMessageBroker()
        {
            var mbg = new MessageBrokerGenerator();
            mbg.Generate();
        }
    }
}

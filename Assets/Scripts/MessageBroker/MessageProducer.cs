using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    public class MessageProducer : MonoBehaviour
    {
        public RequestMessage message;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SendMessage());
        }

        IEnumerator SendMessage()
        {
            Debug.Log("Start coroutine");
            yield return new WaitForSeconds(5);
            object payload = "string";
            Debug.Log("Sending message");
            var response = message.SendMessage();
            Debug.Log(response);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
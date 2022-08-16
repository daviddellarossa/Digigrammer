using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    public class MessageProducer : MonoBehaviour
    {
        public RequestMessage message1;

        public RequestMessage message2;
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
            Debug.Log("Sending message1");
            //var response1 = message1.SendMessage();
            //Debug.Log(response1);
            yield return new WaitForSeconds(5);
            Debug.Log("Sending message");
            //var response2 = message2.SendMessage();
            //Debug.Log(response2);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
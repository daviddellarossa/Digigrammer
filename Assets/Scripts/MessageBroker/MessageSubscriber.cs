using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    public class MessageSubscriber : MonoBehaviour
    {
        
        private Messenger messenger;

        [SerializeField] EventDelegate[] m_Delegates = new EventDelegate[0];

        private void Awake()
        {
            this.messenger = FindMessenger();
            if(messenger == null)
            {
                throw new Exception("Messenger not found");
            }
        }

        private Messenger FindMessenger()
        {
            var assetIds = AssetDatabase.FindAssets("Messenger");
            foreach (var assetId in assetIds)
            {
                var path = AssetDatabase.GUIDToAssetPath(assetId);
                var asset = AssetDatabase.LoadAssetAtPath<Messenger>(path);
                if (asset != null)
                {
                    return asset;
                }
            }
            return null;
        }
        private void Update()
        {
            
        }
    }


    [Serializable]
    public class EventDelegate
    {
        public int eventIndex;
        public Message message;
        public string callback;
    }
}

//using System.Linq;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UIElements;

//namespace Assets.Scripts.MessageBroker
//{
//    //[CustomEditor(typeof(MessageSubscriber))]
//    //[CanEditMultipleObjects]
//    public class MessageSubscriberEditorOld : Editor
//    {
//        private Scripts.MessageBroker messenger;
//        private Message[] messages;
//        private string[] messageNames;

//        private int selectedIndex = -1;

//        private void OnEnable()
//        {
//            this.messenger = FindMessenger();
//            this.messages = this.messenger.messages.OrderBy(x => x.name).ToArray();
//            this.messageNames = this.messages.Select(x => x.name).ToArray();
//        }

//        private Scripts.MessageBroker FindMessenger()
//        {
//            var assetIds = AssetDatabase.FindAssets("Messenger");
//            foreach (var assetId in assetIds)
//            {
//                var path = AssetDatabase.GUIDToAssetPath(assetId);
//                var asset = AssetDatabase.LoadAssetAtPath<Scripts.MessageBroker>(path);
//                if (asset != null)
//                {
//                    return asset;
//                }
//            }
//            return null;
//        }
//        public override void OnInspectorGUI()
//        {
//            base.OnInspectorGUI();
//            serializedObject.Update();
//            var popupLabel = new GUIContent("Event", "Select the event to subscribe to");
//            selectedIndex = EditorGUILayout.Popup(popupLabel, selectedIndex, messageNames, new UnityEngine.GUILayoutOption[0]);

//            var selectedEvent = messages[selectedIndex];

//        }
//    }
//}

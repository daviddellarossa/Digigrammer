using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.MessageBroker
{
    [CustomEditor(typeof(MessageSubscriber))]
    [CanEditMultipleObjects]
    public class MessageSubscriberEditor : Editor
    {
        SerializedProperty m_DelegatesProperty;

        GUIContent m_IconToolbarMinus;
        GUIContent m_EventIDName;

        //(Name, Tooltip) array of events, extracted by MessageBroker
        GUIContent[] m_EventTypes;

        RequestMessage[] requestMessages;

        GUIContent m_AddButtonContent;


        protected virtual void OnEnable()
        {
            m_DelegatesProperty = serializedObject.FindProperty(nameof(MessageSubscriber.Messages));
            m_AddButtonContent = EditorGUIUtility.TrTextContent("Add New Event Type");
            m_EventIDName = new GUIContent("");
            // Have to create a copy since otherwise the tooltip will be overwritten.
            m_IconToolbarMinus = new GUIContent(EditorGUIUtility.IconContent("Toolbar Minus"));
            m_IconToolbarMinus.tooltip = "Remove all events in this list.";

            requestMessages = GetAllMessages();

            m_EventTypes = requestMessages.Select(x => new GUIContent(x.name, x.Tooltip)).ToArray();
        }


        private RequestMessage[] GetAllMessages()
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(RequestMessage).Name);  //FindAssets uses tags check documentation for more info
            var a = new RequestMessage[guids.Length];
            for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<RequestMessage>(path);
            }

            return a;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            int toBeRemovedEntry = -1;

            EditorGUILayout.Space();

            Vector2 removeButtonSize = GUIStyle.none.CalcSize(m_IconToolbarMinus);

            for (int i = 0; i < m_DelegatesProperty.arraySize; ++i)
            {
                SerializedProperty delegateProperty = m_DelegatesProperty.GetArrayElementAtIndex(i);
                SerializedProperty callbacksProperty = delegateProperty.FindPropertyRelative(nameof(MessageSubscriber.Entry.Callback));

                SerializedProperty messageProperty = delegateProperty.FindPropertyRelative(nameof(MessageSubscriber.Entry.Message));
                var messageInstance = messageProperty.objectReferenceValue;
                var messageSerialized = new SerializedObject(messageInstance);

                SerializedProperty messageName = messageSerialized.FindProperty(nameof(RequestMessage.Tooltip));
                m_EventIDName.text = messageInstance.name; 

                EditorGUILayout.PropertyField(callbacksProperty, m_EventIDName);
                Rect callbackRect = GUILayoutUtility.GetLastRect();

                Rect removeButtonPos = new Rect(callbackRect.xMax - removeButtonSize.x - 8, callbackRect.y + 1, removeButtonSize.x, removeButtonSize.y);
                if (GUI.Button(removeButtonPos, m_IconToolbarMinus, GUIStyle.none))
                {
                    toBeRemovedEntry = i;
                }

                EditorGUILayout.Space();
            }

            if (toBeRemovedEntry > -1)
            {
                RemoveEntry(toBeRemovedEntry);
            }

            Rect btPosition = GUILayoutUtility.GetRect(m_AddButtonContent, GUI.skin.button);
            const float addButonWidth = 200f;
            btPosition.x = btPosition.x + (btPosition.width - addButonWidth) / 2;
            btPosition.width = addButonWidth;
            if (GUI.Button(btPosition, m_AddButtonContent))
            {
                ShowAddTriggermenu();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveEntry(int toBeRemovedEntry)
        {
            m_DelegatesProperty.DeleteArrayElementAtIndex(toBeRemovedEntry);
        }

        void ShowAddTriggermenu()
        {
            // Now create the menu, add items and show it
            GenericMenu menu = new GenericMenu();
            for (int i = 0; i < m_EventTypes.Length; ++i)
            {
                bool active = true;

                // Check if we already have a Entry for the current eventType, if so, disable it
                for (int p = 0; p < m_DelegatesProperty.arraySize; ++p)
                {
                    SerializedProperty delegateEntry = m_DelegatesProperty.GetArrayElementAtIndex(p);
                    SerializedProperty eventProperty = delegateEntry.FindPropertyRelative(nameof(MessageSubscriber.Entry.Message));
                    if (eventProperty.enumValueIndex == i)
                    {
                        active = false;
                    }
                }
                if (active)
                    menu.AddItem(m_EventTypes[i], false, OnAddNewSelected, i);
                else
                    menu.AddDisabledItem(m_EventTypes[i]);
            }
            menu.ShowAsContext();
            Event.current.Use();
        }

        private void OnAddNewSelected(object index)
        {
            int selected = (int)index;

            m_DelegatesProperty.arraySize += 1;
            SerializedProperty delegateEntry = m_DelegatesProperty.GetArrayElementAtIndex(m_DelegatesProperty.arraySize - 1);
            SerializedProperty messageProperty = delegateEntry.FindPropertyRelative(nameof(MessageSubscriber.Entry.Message));
            messageProperty.objectReferenceValue = requestMessages[selected];
            serializedObject.ApplyModifiedProperties();
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Assets.Scripts.MessageBroker
{
    [AddComponentMenu("Message Broker/Message Subscriber")]
    /// <summary>
    /// Receives events from the MessageBroker and calls registered functions for each event.
    /// </summary>
    /// <remarks>
    /// The MessageSubscriber can be used to specify functions you wish to be called for each MessageBroker event.
    /// You can assign multiple functions to a single event and whenever the MessageSubscriber receives that event it will call those functions in the order they were provided.
    ///
    /// NOTE: Attaching this component to a GameObject will make that object intercept ALL events, and no events will propagate to parent objects.
    /// </remarks>
    /// <example>
    /// There are two ways to intercept events: You could extend MessageSubscriber, and override the functions for the events you are interested in intercepting; as shown in this example:
    /// <code>
    /// <![CDATA[
    /// using UnityEngine;
    /// using UnityEngine.EventSystems;
    ///
    /// public class MessageSubscriberExample : MessageSubscriber
    /// {
    ///     public override void OnBeginDrag(PointerEventData data)
    ///     {
    ///         Debug.Log("OnBeginDrag called.");
    ///     }
    ///
    ///     public override void OnCancel(BaseEventData data)
    ///     {
    ///         Debug.Log("OnCancel called.");
    ///     }
    ///
    ///     public override void OnDeselect(BaseEventData data)
    ///     {
    ///         Debug.Log("OnDeselect called.");
    ///     }
    ///
    ///     public override void OnDrag(PointerEventData data)
    ///     {
    ///         Debug.Log("OnDrag called.");
    ///     }
    ///
    ///     public override void OnDrop(PointerEventData data)
    ///     {
    ///         Debug.Log("OnDrop called.");
    ///     }
    ///
    ///     public override void OnEndDrag(PointerEventData data)
    ///     {
    ///         Debug.Log("OnEndDrag called.");
    ///     }
    ///
    ///     public override void OnInitializePotentialDrag(PointerEventData data)
    ///     {
    ///         Debug.Log("OnInitializePotentialDrag called.");
    ///     }
    ///
    ///     public override void OnMove(AxisEventData data)
    ///     {
    ///         Debug.Log("OnMove called.");
    ///     }
    ///
    ///     public override void OnPointerClick(PointerEventData data)
    ///     {
    ///         Debug.Log("OnPointerClick called.");
    ///     }
    ///
    ///     public override void OnPointerDown(PointerEventData data)
    ///     {
    ///         Debug.Log("OnPointerDown called.");
    ///     }
    ///
    ///     public override void OnPointerEnter(PointerEventData data)
    ///     {
    ///         Debug.Log("OnPointerEnter called.");
    ///     }
    ///
    ///     public override void OnPointerExit(PointerEventData data)
    ///     {
    ///         Debug.Log("OnPointerExit called.");
    ///     }
    ///
    ///     public override void OnPointerUp(PointerEventData data)
    ///     {
    ///         Debug.Log("OnPointerUp called.");
    ///     }
    ///
    ///     public override void OnScroll(PointerEventData data)
    ///     {
    ///         Debug.Log("OnScroll called.");
    ///     }
    ///
    ///     public override void OnSelect(BaseEventData data)
    ///     {
    ///         Debug.Log("OnSelect called.");
    ///     }
    ///
    ///     public override void OnSubmit(BaseEventData data)
    ///     {
    ///         Debug.Log("OnSubmit called.");
    ///     }
    ///
    ///     public override void OnUpdateSelected(BaseEventData data)
    ///     {
    ///         Debug.Log("OnUpdateSelected called.");
    ///     }
    /// }
    /// ]]>
    ///</code>
    /// or you can specify individual delegates:
    /// <code>
    /// <![CDATA[
    /// using UnityEngine;
    /// using UnityEngine.EventSystems;
    ///
    ///
    /// public class MessageSubscriberDelegateExample : MonoBehaviour
    /// {
    ///     void Start()
    ///     {
    ///         MessageSubscriber trigger = GetComponent<MessageSubscriber>();
    ///         MessageSubscriber.Entry entry = new MessageSubscriber.Entry();
    ///         entry.eventID = EventTriggerType.PointerDown;
    ///         entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
    ///         trigger.triggers.Add(entry);
    ///     }
    ///
    ///     public void OnPointerDownDelegate(PointerEventData data)
    ///     {
    ///         Debug.Log("OnPointerDownDelegate called.");
    ///     }
    /// }
    /// ]]>
    ///</code>
    /// </example>
    public class MessageSubscriber :
        MonoBehaviour
    {
        //[Serializable]
        ///// <summary>
        ///// UnityEvent class for Triggers.
        ///// </summary>
        //public class TriggerEvent : UnityEvent<BaseEventData>
        //{ }

        [Serializable]
        public class RequestMessageEvent : UnityEvent<RequestMessagePayload> { }

        [Serializable]
        /// <summary>
        /// An Entry in the EventSystem delegates list.
        /// </summary>
        /// <remarks>
        /// It stores the callback and which event type should this callback be fired.
        /// </remarks>
        public class Entry
        {
            public RequestMessage message;

            public string Tooltip ="Tooltip";

            /// <summary>
            /// The desired TriggerEvent to be Invoked.
            /// </summary>
            public RequestMessageEvent callback = new RequestMessageEvent();
        }

        [SerializeField]
        private List<Entry> m_Delegates;

        protected MessageSubscriber()
        { 
        }

        private void Awake()
        {
            foreach(var m in m_Delegates)    
            {
                m.message.MessageUnityEvent.AddListener(Execute);
                //m.callback.AddListener(Execute);
            }
        }

        private void OnDestroy()
        {
            foreach (var m in m_Delegates)
            {
                m.message.MessageUnityEvent.RemoveAllListeners();
                //m.callback.RemoveAllListeners();
            }
        }

        private void Start()
        {
            
        }


        /// <summary>
        /// All the functions registered in this MessageSubscriber
        /// </summary>
        public List<Entry> triggers
        {
            get
            {
                if (m_Delegates == null)
                    m_Delegates = new List<Entry>();
                return m_Delegates;
            }
            set 
            { 
                m_Delegates = value; 
            }
        }

        private void Execute(RequestMessagePayload payload)
        {
            Debug.Log("Executing...");
        }
    }

}

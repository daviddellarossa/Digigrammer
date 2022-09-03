using InFlammis.MessageBroker;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts.Common
{
    [CreateAssetMenu(menuName = "Digigrammer/Static Objects Container", fileName = "StaticObjects")]
    class StaticObjectsSO : ScriptableObject
    {
        #region Inspector
        [Header("References")]
        [SerializeField] private MessageBroker _messageBroker;

        #endregion

        #region Private variables
        private EventSystem _eventSystem;
        #endregion

        #region Properties
        public IMessageBroker MessageBroker => _messageBroker;

        public EventSystem EventSystem { get => _eventSystem; set => _eventSystem = value; }
        #endregion
    }
}

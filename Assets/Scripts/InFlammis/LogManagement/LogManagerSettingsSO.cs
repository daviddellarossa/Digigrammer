using UnityEngine;

namespace Digigrammer.Assets.Scripts.InFlammis.LogManagement
{
    [CreateAssetMenu(menuName = "InFlammis/MessageBroker/LogManager Settings", fileName = "LogManager Settings")]
    public class LogManagerSettingsSO : ScriptableObject
    {
        public bool _logEnabled = false;
        public Level _filterLevel = Level.Assert;
    }
}

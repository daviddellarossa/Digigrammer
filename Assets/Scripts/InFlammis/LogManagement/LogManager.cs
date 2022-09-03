using Assets.Scripts.Common;
using System;
using UnityEngine;

namespace Assets.Scripts.InFlammis.LogManagement
{
    class LogManager : MonoBehaviour
    {
        [SerializeField] private LogManagerSettingsSO _settings;
        [SerializeField] private StaticObjectsSO _staticObjects;

        public bool logEnabled => _settings._logEnabled;
        public Level filterLevel => _settings._filterLevel;

        void Awake()
        {
            this._staticObjects.MessageBroker.App.Startup += App_Startup_EventHandler;
            this._staticObjects.MessageBroker.App.Shutdown += App_Shutdown_EventHandler;

            this._staticObjects.MessageBroker.Render.TextureUpdated += Render_TextureUpdated_EventHandler;

        }

        public bool IsLogTypeAllowed(Level logType)
        {
            return logType >= filterLevel;
        }

        public void Log(Level level, object message)
        {
            if (logEnabled && IsLogTypeAllowed(level))
            {
                Debug.Log(message);
            }
        }

        public void Log(Level level, object message, UnityEngine.Object context)
        {
            if (logEnabled && IsLogTypeAllowed(level))
            {
                Debug.Log(message, context);
            }
        }

        public void LogError(string tag, object message)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Error))
            {
                Debug.LogError(message);
            }
        }

        public void LogError(string tag, object message, UnityEngine.Object context)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Error))
            {
                Debug.LogError(message, context);
            }
        }

        public void LogException(Exception exception)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Exception))
            {
                Debug.LogException(exception);
            }
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Exception))
            {
                Debug.LogException(exception, context);
            }
        }

        public void LogWarning(string tag, object message)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Warning))
            {
                Debug.LogWarning(message);
            }
        }

        public void LogWarning(string tag, object message, UnityEngine.Object context)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Warning))
            {
                Debug.LogWarning(message, context);
            }
        }

        public void LogEvent(string publisher, string target, string eventName)
        {
            if (logEnabled && IsLogTypeAllowed(Level.Event))
            {
                Debug.Log($"Pub: {publisher} - Event: {eventName} - Target: {target}");
            }
        }

        public void Render_TextureUpdated_EventHandler(object sender, object target, RenderTexture renderTexture)
        {
            LogEvent(sender.GetType().Name, target as string, "Texture Updated");
        }

        public void App_Shutdown_EventHandler(object sender, object target)
        {
            LogEvent(sender.GetType().Name, target as string, "App Shutdown");
        }

        public void App_Startup_EventHandler(object sender, object target)
        {
            LogEvent(sender.GetType().Name, target as string, "App Startup");
        }

    }

    public enum Level
    {
        Assert,
        Debug,
        Information,
        Event,
        Warning,
        Exception,
        Error,
        Panic
    }
}

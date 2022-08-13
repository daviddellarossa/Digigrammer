﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MessageBroker
{
    [CreateAssetMenu(menuName = "Digigrammer/MessageBroker/Messenger", fileName = "Messenger")]

    public class Messenger : ScriptableObject
    {
        public Message UpdateTexture;

        public List<Message> messages;
    }
}

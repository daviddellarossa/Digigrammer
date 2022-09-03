using System;
using UnityEngine;

namespace Assets.Scripts.Masks
{
    [Serializable]
    class Mask : IMask
    {
        public Texture2D Texture { get; set; }
    }
}

﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    [CreateAssetMenu(menuName = "Digigrammer/Scheduler/Schedule", fileName = "New Schedule")]
    public class ScheduleSO : ScriptableObject
    {
        public List<Step> Steps = new ();
    }
}

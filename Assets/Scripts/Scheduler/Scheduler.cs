﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    [Serializable]
    class Scheduler : IScheduler
    {
        public ISchedule Schedule { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

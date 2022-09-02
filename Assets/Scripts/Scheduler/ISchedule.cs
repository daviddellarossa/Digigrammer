using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    interface ISchedule
    {
        List<IBaseStep> Steps { get; }
    }
}
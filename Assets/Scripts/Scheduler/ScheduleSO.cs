using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scheduler
{
    [CreateAssetMenu(menuName = "Digigrammer/Scheduler/Schedule", fileName = "New Schedule")]
    class ScheduleSO : ScriptableObject, ISchedule
    {
        public List<IBaseStep> Steps { get; set; }
    }
}

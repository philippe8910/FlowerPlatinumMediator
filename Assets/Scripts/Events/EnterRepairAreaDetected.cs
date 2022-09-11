using UnityEngine;

namespace Events
{
    public class EnterRepairAreaDetected
    {
        public RepairArea repairArea;
        public string stateName;

        public EnterRepairAreaDetected(RepairArea _set , string _stateName)
        {
            repairArea = _set;
            stateName = _stateName;
        }
    }
}
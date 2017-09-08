namespace VRTK {
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class tool_template : MonoBehaviour
    {
        public VRTK_ControllerEvents controller_events;

        void Start(){
            controller_events = GetComponent<VRTK_ControllerEvents>();
        }

        public abstract void DoTriggerReleased();
        public abstract void DoTriggerPressed();

    }
}

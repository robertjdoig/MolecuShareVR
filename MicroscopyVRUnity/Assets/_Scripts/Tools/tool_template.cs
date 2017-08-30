namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class tool_ : MonoBehaviour {

        [SerializeField]
        private VRTK_ControllerEvents controller_events;
    
    
    	// Use this for initialization
    	void Start () {
            controller_events.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            controller_events.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
    	}
    	
    	// Update is called once per frame
    	void Update () {}

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            /** Happens when the Trigger is pressed */
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            /** Happens when the Trigger is released */
        }
    }
}


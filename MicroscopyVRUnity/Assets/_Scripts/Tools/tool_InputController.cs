namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class tool_InputController : MonoBehaviour
    {
        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        [SerializeField]
        private GameObject currentTool;

        [SerializeField]
        private tool_template tool;

        // Use this for initialization
        void Start()
        {
            controller_events = GetComponent<VRTK_ControllerEvents>();
            //GetActiveTool(1);

            controller_events.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            controller_events.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e){

            if (tool != null)
            {
                tool.DoTriggerReleased();

            }
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e) {
            if (tool != null)
            {
                tool.DoTriggerPressed();
            }
        }

        public void GetActiveTool(GameObject ctool){
            currentTool =  ctool;
            tool = ctool.GetComponent<tool_template>();

        }

    }
}
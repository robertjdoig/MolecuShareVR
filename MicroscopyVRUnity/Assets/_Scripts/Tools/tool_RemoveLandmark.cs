namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class tool_RemoveLandmark : MonoBehaviour
    {
        [SerializeField]
        private VRTK_ControllerEvents controller_event;

        [SerializeField]
        private GameObject otherLandmark;

        [SerializeField]
        private bool isOverlapping;

        // Use this for initialization
        void Start(){
            controller_event.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            controller_event.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
        }

        // Update is called once per frame
        void Update(){}

        void OnTriggerEnter(Collider other){
            otherLandmark = other.gameObject;
            isOverlapping = true;
        }

        void OnTriggerExit(Collider other){
            isOverlapping = false;
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e){
            //isPressed = true;

            if(isOverlapping == true){
                //Destroy(otherLandmark);

                /** need to check the references in the rulers and delete the ruler first */
                
            }
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e){
            //isPressed = false;
        }
    }
}

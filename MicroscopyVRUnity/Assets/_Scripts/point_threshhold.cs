namespace VRTK.Examples {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class point_threshhold : MonoBehaviour {

        public GameObject otherGO;

        [SerializeField]
        private MeshController mController;

        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        

        // Use this for initialization
        void Start() {

            //Setting the controller_events from parent
            if (gameObject.transform.parent.transform.parent.GetComponent<VRTK_ControllerEvents>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }
            controller_events = gameObject.transform.parent.transform.parent.GetComponent<VRTK_ControllerEvents>();

        }

        // Update is called once per frame
        void Update() {

            if(controller_events.triggerPressed == true)
            {
                if(mController != null)
                {
                    mController.changeThreshholdValue(0.5f);
                }
            }
        }

        public void changeThreshhold()
        {
            if(mController != null)
            {
                float angle = controller_events.GetTouchpadAxisAngle();
                mController.changeThreshholdValue(angle/360*255);
            }
        }


        void OnTriggerEnter(Collider other){
            if(other.tag == "PointCloud")
            {
                otherGO = other.gameObject;
                mController = other.gameObject.GetComponent<MeshController>();
            }
        }
    }
}
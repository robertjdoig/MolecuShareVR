namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class tool_Walking : MonoBehaviour {

        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        [SerializeField]
        private float forward_speed;

        [SerializeField]
        private float rotation_speed;

        [SerializeField]
        private GameObject cameraRig;

        // Use this for initialization
        void Start() {
            //controller_events.triggerAxisChanged += new ControllerActionsEventHandler(DoAxisChanged);
        }

        // Update is called once per frame
        void Update() {

            cameraRig.transform.Rotate(new Vector3(0,controller_events.GetTouchpadAxis().x*rotation_speed,0));
            cameraRig.transform.Translate(Vector3.forward * controller_events.GetTouchpadAxis().y * forward_speed);
        }

    }
}
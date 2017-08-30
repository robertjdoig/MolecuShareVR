namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class tool_PointEraser : MonoBehaviour {

        public Transform cameraRig;
        public Transform leftController;

        public Vector3 controllerPos;

        public float rangeDebug; 

        public GameObject otherGO;

        [SerializeField]
        private MeshController mController;

        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        // Use this for initialization
        void Start(){
            controller_events.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
        }

        // Update is called once per frame
        void Update() { }

        void OnTriggerEnter(Collider other){
            if (other.tag == "PointCloud")
            {
                print("PointCloud Found");
                otherGO = other.gameObject;
                mController = other.gameObject.GetComponent<MeshController>();
            }
            else
            {
                print("PointCloudMissing");
            }
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e){
            Vector3 position = transform.parent.transform.position;
            controllerPos = position;
            float scale = transform.localScale.x * rangeDebug;

            if (mController != null)
            {
                print("Triggered");
                mController.changePointsInRange(position, scale);
            }
        }
    }
}

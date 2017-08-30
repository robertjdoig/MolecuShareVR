namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class point_eraser : MonoBehaviour {

        GameObject cube;// = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject sphere;



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
            //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = gameObject.transform.position;
            //cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            //sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = gameObject.transform.position;
            //sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            //Setting the controller_events from parent
            if (gameObject.transform.parent.transform.parent.GetComponent<VRTK_ControllerEvents>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }
            //controller_events = gameObject.transform.parent.transform.parent.GetComponent<VRTK_ControllerEvents>();


            controller_events.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
        }

        // Update is called once per frame
        void Update() {

            // Vector3 position = cameraRig.position + leftController.position;
            //Vector3 position = leftController.localPosition + cameraRig.localPosition + transform.parent.transform.position;
            //Vector3 position = transform.parent.transform.position;
            //controllerPos = position;
                    //float scale = transform.localScale.x * rangeDebug;

            ////cube.transform.position = position;

            //if (controller_events.triggerPressed == true)
            //{
                //if (mController != null)
                //{
                    //print("Triggered");
                    //mController.changePointsInRange(position, scale);
                //}
            //}

        }

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
             //otherGO = other.gameObject;
             //mesh = otherGO.GetComponent<MeshFilter>().mesh;
             //vertices = mesh.vertices;
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

namespace VRTK {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class tool_AddLandmark : MonoBehaviour {

        [SerializeField]
        private GameObject landmarkPrefab;

        [SerializeField]
        private GameObject currentGO;

        [SerializeField]
        private VRTK_ControllerEvents controller_events;

        // Use this for initialization
        void Start() {
            controller_events.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
        }

        // Update is called once per frame
        void Update() {}

        void Create_Landmark(Vector3 position){
            GameObject lm = Instantiate(landmarkPrefab);
            lm.transform.position = position;
            lm.transform.parent = currentGO.transform.GetChild(1);
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e){
                Create_Landmark(transform.position);
        }

    }
}


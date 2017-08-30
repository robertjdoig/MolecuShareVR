namespace VRTK {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Model_Controller : MonoBehaviour {

        public bool isGrab = true;

        // Use this for initialization
        void Start() {

            switchIsInteractable();
        }

        // Update is called once per frame
        void Update() { }

        public void switchIsInteractable(){

            GameObject landmark_holder = gameObject.transform.GetChild(1).gameObject;

            /** Switching InteractableObjects */
            VRTK_InteractableObject[] ios_landmark = landmark_holder.transform.GetComponentsInChildren<VRTK_InteractableObject>();
            foreach (VRTK_InteractableObject obj in ios_landmark){
                obj.isGrabbable = !isGrab;
            }

            GetComponent<VRTK_InteractableObject>().isGrabbable = isGrab;

            /** Switching Colliders */
            SphereCollider[] sphere_colls = landmark_holder.GetComponentsInChildren<SphereCollider>();
            foreach(SphereCollider sph in sphere_colls)
            {
                sph.enabled = !isGrab;
            }

            GetComponent<BoxCollider>().enabled = isGrab;
            isGrab = !isGrab;
        }

    }
}
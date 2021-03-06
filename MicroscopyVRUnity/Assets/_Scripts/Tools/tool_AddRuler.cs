﻿namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class tool_AddRuler : tool_template {

        [SerializeField]
        private GameObject ruler_prefab;

        [SerializeField]
        private GameObject currentGO;

        [SerializeField]
        private GameObject newRuler;

        [SerializeField]
        private GameObject start_landmark;

        [SerializeField]
        private GameObject end_landmark;

        [SerializeField]
        private GameObject current_landmark;

        private bool isPressed = false;
        // Use this for initialization
        void Start(){}

        // Update is called once per frame
        void Update(){}

        void OnTriggerEnter(Collider other){
            //if (isPressed == true){
            //    start_landmark = other.gameObject;
            //}
            //else if(isPressed == false){
            //    end_landmark = other.gameObject;
            //}

            current_landmark = other.gameObject;
        }

        override public void DoTriggerPressed(){
            //isPressed = true;

            newRuler = Instantiate(ruler_prefab);
            newRuler.transform.parent = currentGO.transform.GetChild(1).GetChild(0);
            newRuler.GetComponent<distToolTip>().p1 = current_landmark;
            newRuler.GetComponent<distToolTip>().p2 = gameObject;
        }

        override public void DoTriggerReleased(){
            //isPressed = false;

            newRuler.GetComponent<distToolTip>().p2 = current_landmark;
        }

    }
}

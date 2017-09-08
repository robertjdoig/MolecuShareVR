using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tool_RemoveLandmark : VRTK.tool_template
{

    [SerializeField]
    private GameObject otherLandmark;

    [SerializeField]
    private bool isOverlapping;

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update(){}

    void OnTriggerEnter(Collider other){
        otherLandmark = other.gameObject;
        isOverlapping = true;
    }

    void OnTriggerExit(Collider other){
        isOverlapping = false;
    }

    override public void DoTriggerPressed(){
        //isPressed = true;

        if(isOverlapping == true){
            //Destroy(otherLandmark);

            /** need to check the references in the rulers and delete the ruler first */
            
        }
    }

    override public void DoTriggerReleased(){
        //isPressed = false;
    }
}


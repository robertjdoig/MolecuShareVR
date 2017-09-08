using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tool_AddLandmark : VRTK.tool_template {

    [SerializeField]
    private GameObject landmarkPrefab;

    [SerializeField]
    private GameObject currentGO;

  
    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void Create_Landmark(Vector3 position){
        GameObject lm = Instantiate(landmarkPrefab);
        lm.transform.position = position;
        lm.transform.parent = currentGO.transform.GetChild(1);
    }

    override public void DoTriggerReleased(){
            Create_Landmark(transform.position);
    }

    public override void DoTriggerPressed(){}

}



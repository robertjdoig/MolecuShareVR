using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tool_PointEraser : VRTK.tool_template {

    public Transform cameraRig;
    public Transform leftController;

    public Vector3 controllerPos;

    public float rangeDebug; 

    public GameObject otherGO;

    [SerializeField]
    private MeshController mController;

    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update() {}

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

    override public void DoTriggerPressed(){
        Vector3 position = transform.parent.transform.position;
        controllerPos = position;
        float scale = transform.localScale.x * rangeDebug;

        if (mController != null)
        {
            print("Triggered");
            mController.changePointsInRange(position, scale);
        }
    }

    override public void DoTriggerReleased(){}
}

 
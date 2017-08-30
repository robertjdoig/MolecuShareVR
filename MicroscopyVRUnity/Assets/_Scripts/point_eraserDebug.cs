
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_eraserDebug : MonoBehaviour {

    public GameObject otherGO;

    public float debug;

    public Vector3 position; 

    [SerializeField]
    private MeshController mController;

    // Use this for initialization
    void Start()
    {
        mController = otherGO.GetComponent<MeshController>();
    }

    // Update is called once per frame
    void Update()
    {

         position = transform.localPosition;
        float scale = transform.localScale.x * debug;
        if (Input.GetButton("Jump"))
        {
            if (mController != null)
            {
                print("Triggered");
                mController.changePointsInRange(position, scale);//15 before
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

     
}

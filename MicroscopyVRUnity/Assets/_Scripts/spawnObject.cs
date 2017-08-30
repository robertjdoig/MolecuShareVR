using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour {

    //private Transform prefabLocation; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnPointCloud(GameObject pointCloud)
    {
        Debug.Log("I am spawning");
        Transform prefabLocation = transform;
        GameObject pcClone = Instantiate(pointCloud, transform.position, Quaternion.identity) as GameObject;
    }
}

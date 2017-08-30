using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationtest : MonoBehaviour {

    public Vector3 position;
    public Vector3 rotation;


	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPos = Vector3.zero;
        newPos = rotateZ(position, rotation.z);
        newPos = rotateX(newPos, rotation.x);
        newPos = rotateY(newPos, rotation.y);
        transform.position = newPos;

	}

    Vector3 rotateZ(Vector3 point, float rot)
    {
        Vector3 point1 = Vector3.zero;
        rot = rot * Mathf.Deg2Rad;
        point1.x = point.x * Mathf.Cos(rot) - point.y * Mathf.Sin(rot); 
        point1.y = point.y * Mathf.Cos(rot) + point.x * Mathf.Sin(rot);
        point1.z = point.z;
        return point1;
    }

    Vector3 rotateX(Vector3 point, float rot)
    {
        Vector3 point1 = Vector3.zero;
        rot = rot * Mathf.Deg2Rad;
        point1.y = point.y * Mathf.Cos(rot) - point.z * Mathf.Sin(rot);
        point1.z = point.z * Mathf.Cos(rot) + point.y * Mathf.Sin(rot);
        point1.x = point.x;
        return point1;
    }


    Vector3 rotateY(Vector3 point, float rot)
    {
        Vector3 point1 = Vector3.zero;
        rot = rot * Mathf.Deg2Rad;
        point1.x = point.x * Mathf.Cos(rot) - point.z * Mathf.Sin(rot);
        point1.z = point.z * Mathf.Cos(rot) + point.x * Mathf.Sin(rot);
        point1.y = point.y;
        return point1;
    }
}

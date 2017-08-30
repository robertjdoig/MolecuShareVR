using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour {

    [SerializeField]
    private MeshFilter[] meshFilters;

    public Vector3 ofset;

    public Vector3 objRot;

	// Use this for initialization
	void Start () {
        meshFilters = GetComponentsInChildren<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update () {
        ofset = transform.localPosition;
        objRot = transform.localRotation.eulerAngles;
        //objRot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }

    public void changePointsInRange(Vector3 centerPosition, float range)
    {
        /** Temp Store variables */
        Vector3[] vertices;
         ofset = transform.position;

        /** Object Rotation */
       // objRot = transform.rotation.eulerAngles;
       
        Debug.Log("Controller" + centerPosition + "ofset" + ofset, gameObject);

        for (int mf = 0; mf < meshFilters.Length; mf++)
        {
            vertices = meshFilters[mf].mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                
                //Vector3 newPos = rotateZ(vertices[i], objRot.z);
                //newPos = rotateX(newPos, objRot.x);
                //newPos = rotateY(newPos, objRot.y);

                if (Vector3.Distance(ofset + vertices[i], centerPosition) <= range)
                {
                    vertices[i] = new Vector3(0, 0, 0); // Add to the saved buffer? remove from old vert array or create a new mesh on save
                }
            }

            meshFilters[mf].mesh.vertices = vertices;

        }
    }

    public void changeThreshholdValue(float threshValue)
    {
        /** ######## Debug ####### */
        print("threshChange");

        /** Temp Store Variables */
        Color[] colors;

        for (int mf = 0; mf < meshFilters.Length; mf++)
        {
            colors = meshFilters[mf].mesh.colors;
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].r > colors[i].g)
                {
                    if (colors[i].r > colors[i].b)
                    {
                        //its a red point
                        colors[i].a = checkThresh(colors[i].r, threshValue);
                    }
                    else
                    {
                        // its a blue point
                        colors[i].a = checkThresh(colors[i].b, threshValue);
                    }
                }
                else if (colors[i].g > colors[i].b)
                {
                    //its a green point
                    colors[i].a = checkThresh(colors[i].g, threshValue);
                }
                else
                {
                    //its a blue point

                    ///////////#################################///////////
                    colors[i].a = checkThresh(colors[i].b, threshValue);
                    //colors[i].b = checkThresh(colors[i].b, threshValue);
                }

            }
            meshFilters[mf].mesh.colors = colors;
        }
    }

    float checkThresh(float colorValue, float threshhold)
    {
        float alpha;
        if (colorValue <= threshhold) { alpha = 0; }
        else { alpha = 255; }
        return alpha;
    }

    Vector3 rotateZ(Vector3 point, float rot)
    {
        Vector3 point1 = Vector3.zero;
        float rot1 = rot * Mathf.Deg2Rad;
        point1.x = point.x * Mathf.Cos(rot1) - point.y * Mathf.Sin(rot1);
        point1.y = point.y * Mathf.Cos(rot1) + point.x * Mathf.Sin(rot1);
        point1.z = point.z;
        return point1;
    }

    Vector3 rotateX(Vector3 point, float rot)
    {
        Vector3 point1 = Vector3.zero;
        float rot1 = rot * Mathf.Deg2Rad;
        point1.y = point.y * Mathf.Cos(rot1) - point.z * Mathf.Sin(rot1);
        point1.z = point.z * Mathf.Cos(rot1) + point.y * Mathf.Sin(rot1);
        point1.x = point.x;
        return point1;
    }


    Vector3 rotateY(Vector3 point, float rot)
    {
        Vector3 point1 = Vector3.zero;
        float rot1 = rot * Mathf.Deg2Rad;
        point1.x = point.x * Mathf.Cos(rot1) - point.z * Mathf.Sin(rot1);
        point1.z = point.z * Mathf.Cos(rot1) + point.x * Mathf.Sin(rot1);
        point1.y = point.y;
        return point1;
    }
}

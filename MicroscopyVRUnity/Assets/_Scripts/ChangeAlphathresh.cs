using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlphathresh : MonoBehaviour {



    public GameObject go;

    public float value;

    MeshFilter mf;
    Mesh mesh;

    MeshFilter[] meshes;

    Color[] colors;

	// Use this for initialization
	void Start () {

        meshes = new MeshFilter[transform.childCount];
        for(int i = 0; i < meshes.Length; i++)
        {
            meshes = GetComponentsInChildren<MeshFilter>();
        }

        //mf = GetComponent<MeshFilter>();
        //mesh = mf.mesh;
       // colors = new Color[mesh.colors.Length];
       // colors = mesh.colors;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            print("Jump");
            for(int i = 0; i < meshes.Length; i++)
            {
                colors = new Color[meshes[i].mesh.colors.Length];
                colors = meshes[i].mesh.colors;

                for (int j = 0; j < colors.Length; j++)
                {
                    //colors[i] = new Color(0, 0, 0, 1);
                    if (colors[j].r <= value)
                    {
                        //print(colors[i].a);
                        colors[j].g = 0;
                        colors[j].a = 0;
                    }
                    else
                    {
                       colors[j].g = 1;
                        colors[j].a = 1 ;
                    }
                }
                meshes[i].mesh.colors = colors;
            }
            }
            // print("Changing Alpha");
          //  colors[0].a = 0;
          //  print(colors[0]);
           // mesh.colors = colors;

        
	}
 
}

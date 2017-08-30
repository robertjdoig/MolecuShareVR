using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingMesh : MonoBehaviour {


    [SerializeField]
    private Mesh mesh;

	// Use this for initialization
	void Start () {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Save"))
        {
            print("Saving");
            UnityEditor.AssetDatabase.CreateAsset(mesh, "Assets/Resources/PointCloud/Meshes/ThisIsTheNewMesh.asset");
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
        }
	}
}

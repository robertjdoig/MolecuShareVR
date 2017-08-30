using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using VRTK;

public class ModelLoader : MonoBehaviour {

    [SerializeField]
    private string[] modelPaths;

    [SerializeField]
    private int modelID;

    [SerializeField]
    private GameObject rectViewPort;

	// Use this for initialization
	void Start () {

        //refreshFilePaths();

        //spawnPrefabClone = Resources.Load("/Rescources/color80present", typeof(GameObject)) as GameObject;
        //GameObject instance = Instantiate(Resources.Load(modelPaths[0], typeof(GameObject))) as GameObject;
    }

    // Update is called once per frame
    void Update () { }

    public void spawnModel(string name, Vector3 position)
    {
        GameObject instance = Instantiate(Resources.Load("PointCloudMeshes/" + name, typeof(GameObject))) as GameObject;
        instance.transform.position = position;

    }

    public void refreshFilePaths(){
        modelPaths = Directory.GetFiles(Application.dataPath + "/Resources/PointCloudMeshes/", "*.prefab");

        string s;
        for (int i = 0; i < modelPaths.Length; i++)
        {
            s = modelPaths[i];
            s = reverseString(s);
            s = cutString(s, '/');

            s = reverseString(s);

            s = cutString(s, '.');

            modelPaths[i] = s;
        }

        rectViewPort.GetComponent<ScrollBarManager>().createMenu(modelPaths);


    }

    private string cutString(string s, char key){
        string _s = s;
        for (int c = 0; c < _s.Length; c++){
            if (_s[c].Equals(key)){
                _s = _s.Substring(0, c);
            }
        }
        return _s;
    }

    string reverseString(string s){
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);

        string result = new string(charArray);
        return result;
    }

    /** Setter */
    public void setModelID(int id) { modelID = id; }

}

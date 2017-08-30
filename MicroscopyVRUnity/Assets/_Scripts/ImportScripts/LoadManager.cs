using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class LoadManager : MonoBehaviour {

    

    [Header ("UI Elements")]

    [SerializeField]
    private bool importAll;

    [SerializeField]
    private string drop_folder;

    [SerializeField]
    private string singleDataPath;

    [SerializeField]
    private string[] datapaths;

    [SerializeField]
    private float Scale;

    [SerializeField]
    private bool ForceReload;

    [SerializeField]
    private string status_text;


    [Header("Debug")] /** change to private when finished debug */
    public GameObject loader_GO;
    public PointCloudManager current_PC_Manager;
    public Material MatVertex;
    public int counter;
    public bool inProgress;
    public float progress;
    public bool isImporting = false;

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () {
        if (isImporting == true)
        {
            if (counter < datapaths.Length)
            {

                if (inProgress == true)
                {
                    status_text = "still working on the point cloud";
                }
                else if (inProgress == false)
                {
                    status_text = "Im done with that work can i have some more";

                    if (datapaths[counter] != null)
                    {
                        //current_PC_Manager.importPoints();
                        createLoader(datapaths[counter]);
                        print("hey its working");
                    }
                }

                progress = current_PC_Manager.getProgress();
                if (progress == 1)
                {
                    //current_PC_Manager.dataPath = datapaths[counter];
                    Destroy(loader_GO);

                    counter++;
                    inProgress = false;

                }
                else if (progress < 1)
                {
                    inProgress = true;
                }
            }
            else
            {
                isImporting = false;
            }
        }
    }

    void createLoader(string name)
    {
        loader_GO = new GameObject();
        loader_GO.name = "Point Cloud Loader";
        current_PC_Manager = loader_GO.AddComponent<PointCloudManager>();

        current_PC_Manager.matVertex = MatVertex;
        current_PC_Manager.dataPath = drop_folder + name;
        current_PC_Manager.scale = Scale;
        current_PC_Manager.forceReload = ForceReload;

        current_PC_Manager.importPoints();
    }



    public void loadPoints()
    {
        switch (importAll){
            case false:
                datapaths = new string[1];
                datapaths[0] = singleDataPath;
                break;
            case true:
                string[] path = Directory.GetFiles(Application.dataPath  + drop_folder,"*.off");
                //path[0] = path[0].Substring(0, path[0].Length - 4);
                //path[0] = reverseString(path[0]);

                string s;
                for(int i = 0; i < path.Length; i++)
                {
                    path[i] = reverseString(path[i]);
                    s = path[i];

                    for (int c = 0; c < s.Length; c++)
                    {
                        if (s[c].Equals('/'))
                        {
                            s = s.Substring(4, c-4);
                        }
                    }
                    s = reverseString(s);
                    path[i] = s;
                }

                datapaths = new string[path.Length];
                //datapaths = extractName(path);
                datapaths = path;

                break;
        }

        counter = 0;
        isImporting = true;
    }

    string reverseString(string s){
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);

        string result = new string (charArray);
        //result = result.Substring(1, 5);
        return result;
    }

    /** Setters */ 
    public void SwitchForceReload(){ ForceReload = !ForceReload; }
    public void SetImportAll(bool state) { importAll = state; }
    public void SetDataPath(InputField textfield) { singleDataPath = textfield.text; }
    public void SetDropFolder(InputField textfield) { drop_folder = textfield.text; }
    public void SetScale(InputField textfield) { Scale = float.Parse(textfield.text);  }
}

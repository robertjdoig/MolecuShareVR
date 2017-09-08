using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class tool_ExportDistances : VRTK.tool_template {

    string path = "Assets/Export/";

    public string fileName;

    // Use this for initialization
    void Start () {
        StreamWriter writer = new StreamWriter(path + fileName + ".txt", true);
        writer.WriteLine("Test");
        writer.Close();


    }
	
	// Update is called once per frame
	void Update () {}

    public override void DoTriggerPressed(){}

    public override void DoTriggerReleased(){


    }

    void createFile()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RadMenuSwitcher : MonoBehaviour {

    [SerializeField]
    private int debug; 

    private GameObject[] rads; 

    [SerializeField]
    private bool isSocket = false;

    [SerializeField]
    private GameObject controller;

	// Use this for initialization
	void Start () {
        int children = transform.childCount;
        rads = new GameObject[children];
        for (int i = 0; i < children; ++i)
            rads[i] = transform.GetChild(i).gameObject;
    }

    public void changeRad(int State)
    {
        debug = State;
       for(int i = 0; i < rads.Length; i++)
        {
            if(i == State)
            {
                rads[i].SetActive(true);
                if(isSocket == true) { 
                     controller.GetComponent<tool_InputController>().GetActiveTool(rads[i]);
                }
            }
            else
            {
                rads[i].SetActive(false);
            }
        }
    } 

}

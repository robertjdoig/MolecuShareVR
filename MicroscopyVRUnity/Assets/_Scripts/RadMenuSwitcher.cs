using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadMenuSwitcher : MonoBehaviour {

    [SerializeField]
    private int debug; 

    private GameObject[] rads; 

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
            }
            else
            {
                rads[i].SetActive(false);
            }
        }
    } 

}

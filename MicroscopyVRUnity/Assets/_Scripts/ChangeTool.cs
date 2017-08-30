using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour {

    [SerializeField]
    private GameObject[] tools;

    public void setCurrentTool(int State)
    {
        
        for(int i = 0; i < tools.Length; i++)
        {
            if(i == State)
            {
                tools[i].SetActive(true);
            }
            else
            {
                tools[i].SetActive(false);
            }
        }
    }




    // Referencing with VRTK isnt working when setting the controller events variables. Will fix and readd this at a later date.
    public void ChangeCurrentTool(GameObject newSelectedTool)
    {
        foreach(Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject tool = Instantiate(newSelectedTool, gameObject.transform.position, gameObject.transform.rotation);
        tool.transform.parent = gameObject.transform;
    }
}

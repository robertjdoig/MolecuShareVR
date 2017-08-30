using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scene_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

    public void LoadScene(int sceneID)
    {
        //SceneManager.LoadScene(sceneID, LoadSceneMode.Single);
        Application.LoadLevel(sceneID);

        /****************************************************
         * Should be using SceneManager as LoadLevel is deprecated 
         * however its not working as expected
        ****************************************************/
    }
}

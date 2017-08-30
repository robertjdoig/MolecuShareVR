using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class UISwitcher : MonoBehaviour {

    [SerializeField]
    private GameObject firstTab;

    [SerializeField]
    private GameObject secondTab;

    /** Setters */
    public void switchTabs(bool state){
        firstTab.SetActive(!state);
        secondTab.SetActive(state);
    }

}

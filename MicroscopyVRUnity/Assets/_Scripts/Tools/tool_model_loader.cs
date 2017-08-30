using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class tool_model_loader : MonoBehaviour
{

    [SerializeField]
    private GameObject rectScrollBar;

    [SerializeField]
    private string[] names;

    [SerializeField]
    private float position;

    [SerializeField]
    private ScrollBarManager scroll_bar_manager;

    // Use this for initialization
    void Start()
    {
        scroll_bar_manager = rectScrollBar.GetComponent<ScrollBarManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            scroll_bar_manager.createMenu(names);
        }
        position = Input.GetAxis("Vertical");
        scroll_bar_manager.UpdatePosition(position);
    }

    void MoveScrollBar()
    {


    }
}

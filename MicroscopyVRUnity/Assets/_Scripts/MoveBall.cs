using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {
    [SerializeField]
    float horiSpeed;

    [SerializeField]
    float vertSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * horiSpeed, Input.GetAxis("Vertical") * vertSpeed, 0));
    }
}

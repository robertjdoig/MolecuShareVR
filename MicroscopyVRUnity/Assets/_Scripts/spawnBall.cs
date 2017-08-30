using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour {

    public void spawnCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();
        cube.transform.position = gameObject.transform.position;
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void spawnSphere()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cube.AddComponent<Rigidbody>();
        cube.transform.position = gameObject.transform.position;
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }
}

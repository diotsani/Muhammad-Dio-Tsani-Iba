using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(x, y, z * Time.deltaTime);
    }
}

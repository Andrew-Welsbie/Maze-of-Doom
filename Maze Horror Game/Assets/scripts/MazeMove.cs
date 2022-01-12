using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMove : MonoBehaviour
{
    public float xScale;
    public float yScale;
    public float zScale;



    public void Update()
    {
        transform.position = new Vector3(xScale, yScale, zScale);
    }

}
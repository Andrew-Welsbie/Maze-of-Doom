
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MazeScaler : MonoBehaviour
{
    public float scale;
    public Transform wallScale;


    public void Update()
    {
        wallScale.localScale = new Vector3(scale, scale, scale);
    }

}
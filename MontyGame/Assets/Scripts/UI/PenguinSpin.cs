using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpin : MonoBehaviour
{
    [Range(0f, 100f)]
    public float xRotation;
    [Range(0f, 100f)]
    public float yRotation;
    [Range(0f, 100f)]
    public float zRotation;
    public bool randomize;

    private void Update()
    {
        if (randomize)
        {
            transform.Rotate(new Vector3(Random.Range(0, xRotation), Random.Range(0, yRotation), Random.Range(0, zRotation)));
        }
        else
        {
            transform.Rotate(new Vector3(xRotation, yRotation, zRotation));
        }
    }
}

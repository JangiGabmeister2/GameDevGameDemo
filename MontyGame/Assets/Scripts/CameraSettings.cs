using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }
}

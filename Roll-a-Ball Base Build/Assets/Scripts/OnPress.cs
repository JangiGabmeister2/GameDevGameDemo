using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPress : MonoBehaviour
{
    public UnityEvent keyPress;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            keyPress.Invoke();
        }
    }
}

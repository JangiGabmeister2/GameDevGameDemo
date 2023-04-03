using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnEmpty : MonoBehaviour
{
    public UnityEvent onEmpty;
    // Update is called once per frame
    void Update()
    {
        // Check if there are no more children left
        if (transform.childCount == 0)
        {
            // Run the subscribed events
            onEmpty.Invoke();
            // Disable the script... So update doesn't get called again... LOL
            enabled = false;
        }
    }
}

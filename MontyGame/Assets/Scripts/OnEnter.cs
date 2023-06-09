using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    public string hitTag = "";
    public bool destroySelf = false;
    public bool destroyOther = false;
    public UnityEvent onEnter;
    public UnityEvent onExit;
 
    void HandleCollision(Collider collider)
    {
        //if a collision happens with the required tag
        if (hitTag == collider.tag)
        {
            //if enemy destroy player
            if (destroyOther)
            {
                Destroy(collider.gameObject);
            }
            //if collectable destroy collectable
            if(destroySelf)
            {
                Destroy(gameObject);
            }
            //run the event
            onEnter.Invoke();
        }
    }
    void OffTrigger(Collider collider)
    {
        if (collider.tag == "Player")
        {
            onExit.Invoke();
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        HandleCollision(trigger);
    }
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.collider);
    }
    private void OnTriggerExit(Collider other)
    {
        OffTrigger(other);
    }
}

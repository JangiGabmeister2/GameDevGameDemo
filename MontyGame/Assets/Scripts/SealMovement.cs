using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealMovement : MonoBehaviour
{
    public float movementSpeed;
    public Transform[] positions;

    private int positionsIndex = 0;

    private void Start()
    {
        RotateTransform(positions[positionsIndex].position);
    }

    private void Update()
    {
        MoveTransform();
    }

    //moves the seal transform along an array of waypoint empty gameobjects in the scene
    private void MoveTransform()
    {
        Vector3 objectPosition = positions[positionsIndex].position;
        transform.position = Vector3.Lerp(transform.position, objectPosition, movementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, objectPosition) < 0.5f)
        {
            positionsIndex++;
            RotateTransform(objectPosition);
        }

        if (positionsIndex == positions.Length)
        {
            System.Array.Reverse(positions);
            positionsIndex = 0;
        }
    }
    
    private void RotateTransform(Vector3 position)
    {
        Vector3 direction = (transform.position - position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1000);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoneOrNot : MonoBehaviour
{
    int choice;
    // Start is called before the first frame update
    void Start()
    {
        choice = Random.Range(1, 100);
    }

    // Update is called once per frame
    public void Choose()
    {
        if (choice > 50)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] Transform[] teleportPoints;
    private float waitTime = 2f;
    private bool teleport = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Teleport")
        {
            if (other.gameObject.name == "0" && teleport)
            {
                teleport = false;
                transform.position = teleportPoints[1].transform.position;
                Invoke(nameof(CanTeleport), waitTime);
                Debug.Log("1. teleport");
            }
            if(other.gameObject.name == "1" && teleport)
            {
                teleport = false;
                transform.position = teleportPoints[0].transform.position;
                Invoke(nameof(CanTeleport), waitTime);
                Debug.Log("2. teleport");
            }
        }

    }

    

    void CanTeleport()
    {
        teleport = true;
    }
}

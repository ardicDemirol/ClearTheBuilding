using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        //Destroy(gameObject,2f);    
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Poison")
        {
            Destroy(collision.gameObject,0.75f);
        }
    }
}

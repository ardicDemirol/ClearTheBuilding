using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    
    [SerializeField] Transform[] trapLocations;
    [SerializeField] GameObject poisonPrefab;
    [SerializeField] Rigidbody poisonRigidbody;

    [SerializeField] private float downSpeed = -10f;
    [SerializeField] float spawnTime = 2f;
    private float timer=0f;
    
    

    void Start()
    {
        poisonRigidbody = poisonPrefab.GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        SpawnPoison();
        
    }

    void SpawnPoison()
    {
        if(timer >= spawnTime)
        {
            Debug.Log("ifin içindeyim");
            for (int i = 0; i < trapLocations.Length; i++)
            {
                Instantiate(poisonPrefab, trapLocations[i].transform.position, Quaternion.identity);
                poisonRigidbody.AddForce(1f,downSpeed,1f,ForceMode.Impulse);

                Debug.Log("forun içindeyim");
            }
            Debug.Log("fordan çýktým");
            timer = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Çarptý");
        }
        
    }

}

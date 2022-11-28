using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    public GameObject owner;


    [SerializeField] private int point;
    private int score = 0;
    [SerializeField] private bool isPlayer = false;


    void Start()
    {
        
    }

    void Update()
    {
        transform.position += -transform.up * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.GetComponent<Target>() == false)     // Temas etti�i objenin target scripti yoksa bu ko�ul sa�lan�r
        {
            Destroy(gameObject);
        }
       if(other.gameObject.tag == "Enemy")
        {
            score += point;
            Debug.Log(point);
        }
    }
}

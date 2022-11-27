using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    private int currentHealth;

    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject deathFx;

    private AudioSource audioSource;
    [SerializeField] private AudioClip clipToPlay;

    public int GetHealth
    {
        get 
        { 
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentHealth--; 
        }

    }

  

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if(bullet == true)  // It checks whether the bullet code exists in the object that touches the object with this code.
        {
            if(bullet.owner != gameObject)
            {
                currentHealth--;
                audioSource.PlayOneShot(clipToPlay);
                if(hitFx != null && currentHealth > 0)
                {
                    Instantiate(hitFx,transform.position,Quaternion.identity);
                    
                    
                }
                if (currentHealth <= 0)
                {
                    Die();
                }
               

                Destroy(other.gameObject);
                

            }

            

        }
    }

    void Die()
    {
        if (deathFx != null)
        {
            Instantiate(deathFx, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}

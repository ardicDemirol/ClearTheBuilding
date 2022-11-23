using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healthPowerUp = false;
    public int healthAmount = 1;
    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 1;
    [Header("Transform Settings")]
    [SerializeField] private float turnSpeed = -1f;




    void Start()
    {
        if (healthPowerUp == true && ammoPowerUp == true)
        {
            healthPowerUp = false;
            ammoPowerUp = false;
        }
        else if (healthPowerUp == true) ammoPowerUp = false;
        else if (ammoPowerUp) healthPowerUp = false;
    }

    void Update()
    {
        transform.Rotate(0f, turnSpeed, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            return;
        }
        if (healthPowerUp)
        {
            other.gameObject.GetComponent<Target>().GetHealth += healthAmount;
        }
        else if (ammoPowerUp)
        {
            other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
        }
        Destroy(gameObject);

    }
}

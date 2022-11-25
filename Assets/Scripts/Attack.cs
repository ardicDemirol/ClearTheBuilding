using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int maxAmmoCount = 5;
    [SerializeField] private bool isPlayer = false;
    private int ammoCount = 0;
    

    [SerializeField] private float fireRate = 0.5f;

    private float currentFireRate = 0f;

    public float GetCurrentFireRate
    {
        get
        {
            return currentFireRate;
        }
        set
        {
            currentFireRate = value;
        }
    }
    public int GetAmmo
    {
        get
        {
            return ammoCount;
        }
        set
        {
            ammoCount = value;
            if (ammoCount > maxAmmoCount)
            {
                ammoCount = maxAmmoCount;
            }
        }
    }
    public int GetClipSize
    {
        get
        {
            return maxAmmoCount;
        }
    }


    void Start()
    {
        ammoCount = maxAmmoCount;
    }

    void Update()
    {
        Shooting();
    }


    void Shooting()
    {
        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireRate <= 0 && ammoCount > 0)
                {
                    Fire();

                }
            }
        }
       
            
    }

    public void Fire()
    {
        float difference = 180f - transform.eulerAngles.y;
        float targetRotation = -90f;

        if (difference >= 90f)
        {
            targetRotation = 270f;
        }
        else if(difference < 90f)
        {
            targetRotation = 90f;
        }
        ammoCount--;
        currentFireRate = fireRate;
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation)) ;
        bulletClone.GetComponent<Bullet>().owner = gameObject;   //Ateþlediðimiz mermiyi kimin ateþlediðini (yani içinde bu scriptin bulunduðu gameObjecti) buluyoruz
                                                                 //.Böylece merminin kendimize çarpmasýna engel oluyoruz.)
    }
}

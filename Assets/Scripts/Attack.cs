using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject ammo;
    [SerializeField] private bool isPlayer = false;


    private int ammoCount = 0;
    private float fireRate = 0.5f;
    [SerializeField] private Transform fireTransform;
    private int maxAmmoCount = 5;
    private AudioClip clipToPlay;
    private AudioSource audioSource;


    private float currentFireRate = 0f;
    private GameManager gameManager;

    public AudioClip GetClipToPlay
    {
        get
        {
            return clipToPlay;
        }
        set
        {
            clipToPlay = value;
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
    public int GetClipSize
    {
        get
        {
            return maxAmmoCount;
        }
        set
        {
            maxAmmoCount = value;
        }
    }
    public float GetFireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }

    public Transform GetFireTransform
    {
        get
        {
            return fireTransform;
        }
        set
        {
            fireTransform = value;
        }
    }








    void Awake()
    {
        audioSource = GetComponent<AudioSource>();  
        gameManager = FindObjectOfType<GameManager>();
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
        if (isPlayer && !gameManager.GetLevelFinish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireRate <= 0 && ammoCount > 0)
                {
                    Fire();

                }
            }
            switch (Input.inputString)
            {
                case "1":
                    for (int i = 0; i < weapons.Length; i++)
                    {
                        weapons[i].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount= ammoCount;
                        weapons[i].gameObject.SetActive(false);
                        weapons[0].gameObject.SetActive(true);
                    }
                    break;
                case "2":
                    for (int i = 0; i < weapons.Length; i++)
                    {
                        weapons[i].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount;
                        weapons[i].gameObject.SetActive(false);
                        weapons[1].gameObject.SetActive(true);
                    }
                    break;
                case "3":
                    for (int i = 0; i < weapons.Length; i++)
                    {
                        weapons[i].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount;
                        weapons[i].gameObject.SetActive(false);
                        weapons[2].gameObject.SetActive(true);
                    }
                    break;
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
        else if (difference < 90f)
        {
            targetRotation = 90f;
        }
        ammoCount--;
        currentFireRate = fireRate;
        audioSource.PlayOneShot(clipToPlay);
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;   //Ateþlediðimiz mermiyi kimin ateþlediðini (yani içinde bu scriptin bulunduðu gameObjecti) buluyoruz
                                                                 //.Böylece merminin kendimize çarpmasýna engel oluyoruz.)
    }
}

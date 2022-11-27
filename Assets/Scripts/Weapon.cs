using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Attack attack;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int clipSize;
    [SerializeField] private float fireRate;
    [SerializeField] private AudioClip clip;
    private int currentAmmoCount;
    public int GetCurrentWeaponAmmoCount
    {
        get
        {
            return currentAmmoCount;
        }
        set
        {
            currentAmmoCount = value;   
        }
    }

    private void Awake()
    {
        currentAmmoCount = clipSize;
    }


    private void OnEnable()  // Objemiz aktif olduðu zaman bu methodun içi çalýþýr
    {
        if(attack != null)
        {
            attack.GetFireTransform = fireTransform;
            attack.GetClipSize = clipSize;
            attack.GetFireRate = fireRate;
            attack.GetAmmo = currentAmmoCount;
            attack.GetClipToPlay = clip;

        }
    }
}

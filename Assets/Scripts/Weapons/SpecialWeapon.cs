using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecialWeapon : MonoBehaviour
{
    [Header("Set Up")]
    public Transform firePoint;
    public BaseSpecialWeapon weaponType;
    public int startingAmmo;
    public TextMeshProUGUI specialAmmoText;

    private int ammo;

    private void Start()
    {
        ammo = startingAmmo;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && ammo >0)
        {
            Shoot();
        }

        specialAmmoText.text = "Ammo  " + ammo.ToString();
    }

    public void Shoot()
    {
        Instantiate(weaponType.projectileType, firePoint.position, firePoint.transform.rotation);
        ammo -= 1;
    }
}


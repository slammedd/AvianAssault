using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrimaryWeapon : MonoBehaviour
{
    [Header("Set Up")]
    public Transform firePoint;
    public BasePrimaryWeapon weaponType;
    public int startingAmmo;
    public TextMeshProUGUI ammoText;

    private int ammo;

    private void Start()
    {
        ammo = startingAmmo;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo >0)
        {
            Shoot();
        }

        ammoText.text = "Ammo  " + ammo.ToString();
    }

    public void Shoot()
    {
        Instantiate(weaponType.projectileType, firePoint.position, firePoint.transform.rotation);
        ammo -= 1;
    }
}

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
    private float firingTimer;

    private void Start()
    {
        ammo = startingAmmo;
    }


    private void Update()
    {
        if(firingTimer >= 0)
        {
            firingTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && ammo > 0)
        {
            if (firingTimer < 0)
            {
                Shoot();
                firingTimer += weaponType.fireDelay;
            }
        }

        ammoText.text = "Ammo  " + ammo.ToString();
    }

    public void Shoot()
    {
        Instantiate(weaponType.projectileType, firePoint.position, firePoint.transform.rotation);
        ammo -= 1;
    }
}

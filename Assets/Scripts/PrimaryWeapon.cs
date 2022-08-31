using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon : MonoBehaviour
{
    [Header("Set Up")]
    public Transform firePoint;
    public BasePrimaryWeapon weaponType;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(weaponType.projectileType, firePoint.position, firePoint.transform.rotation);
    }
}

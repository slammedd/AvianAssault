using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    [Header("Set Up")]
    public Transform firePoint;
    public BaseSpecialWeapon weaponType;


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(weaponType.projectileType, firePoint.position, firePoint.transform.rotation);
    }
}


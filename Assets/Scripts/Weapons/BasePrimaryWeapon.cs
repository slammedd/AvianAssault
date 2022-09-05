using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PrimaryWeapon", order = 1)]
public class BasePrimaryWeapon : ScriptableObject
{
    public GameObject projectileType;
    public float fireDelay;
}

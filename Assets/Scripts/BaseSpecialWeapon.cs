using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpecialWeapon", order = 2)]
public class BaseSpecialWeapon : ScriptableObject
{
    public GameObject projectileType;
}

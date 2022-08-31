using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [Header("Basic Projectile")]
    public float projectileSpeed;
    public Rigidbody2D rb;

    [Header("Homing Projectile")]
    public bool isHoming;
    public HomingBehaviour homingBehaviour;


    private void Update()
    {
        if (isHoming && homingBehaviour.target != null)
        {
            homingBehaviour.Homing();
        }
    }

    private void Start()
    {
        rb.velocity = rb.transform.up * projectileSpeed;
    }
}

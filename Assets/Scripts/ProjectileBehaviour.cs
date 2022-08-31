using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = rb.transform.up * projectileSpeed; 
    }
}

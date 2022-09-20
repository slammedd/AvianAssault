using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [Header("Basic Projectile")]
    public float projectileSpeed;
    public Rigidbody2D rb;
    public ParticleSystem impactParticles;
    public float lifetime;

    [Header("Homing Projectile")]
    public bool isHoming;
    public HomingBehaviour homingBehaviour;

    private void Start()
    {
        rb.velocity = rb.transform.up * projectileSpeed;

        Invoke("Destroy", lifetime);
    }

    private void Update()
    {
        if (isHoming && homingBehaviour.target != null)
        {
            homingBehaviour.Homing();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Instantiate(impactParticles, contact.point, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Instantiate(impactParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

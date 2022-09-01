using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBehaviour : MonoBehaviour
{
    [HideInInspector] public Transform target;
    public float angleChangingSpeed;
    public float projectileSpeed;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            target = collision.gameObject.transform;
            print(target);
        }
    }



    public void Homing()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -angleChangingSpeed * rotateAmount;
        rb.velocity = transform.up * projectileSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Asteroid : MonoBehaviour
{
    private int health;
    public float scaleSpeed;

    private void Start()
    {
        health = GameObject.Find("Interactions Manager").GetComponent<InteractionsManager>().asteroidHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health -= 1;
        }

        if (health == 0)
        {
            transform.DOScale(new Vector3(0, 0, 0), scaleSpeed);
            Invoke("DeleteObject", 3);
        }
    }

    private void DeleteObject()
    {
        GameObject.Destroy(gameObject);
    }
}

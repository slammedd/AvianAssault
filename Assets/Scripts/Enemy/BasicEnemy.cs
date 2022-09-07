using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    private Transform player;
    private Vector2 movement;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;
        direction.Normalize();
        movement = direction;
       
        MoveCharacter(movement);
    }

    public void MoveCharacter(Vector2 direction)
    {
        transform.position = ((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }
}

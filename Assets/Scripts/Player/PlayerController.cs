using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Assignables")]
    public Rigidbody2D rb;
    public ParticleSystem upThrusterParticles;
    public ParticleSystem rightThrusterParticles;
    public ParticleSystem leftThrusterParticles;
    public Transform leftBooster;
    public Transform rightBooster;
    public Animator heart1Anim;
    public Animator heart2Anim;
    public Animator heart3Anim;
    public Animator heart4Anim;
    public Animator heart5Anim;

    [Header("Player Stats")]
    public float upThrust;
    public float turnThrust;
    public float maxSpeed;
    private int health = 5;

    [Header("Camera")]
    public CinemachineVirtualCamera vCam;
    public float zoomSensitivity;

    private void Start()
    {
        vCam.m_Lens.OrthographicSize = 7.5f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUpwards();
            upThrusterParticles.Play();
        }

        else upThrusterParticles.Stop();

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();

            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }

        else rightThrusterParticles.Stop();

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();

            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }

        else leftThrusterParticles.Stop();

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(1);
        }
    }

    private void MoveUpwards()
    {
        rb.AddForce(transform.up * upThrust * Time.deltaTime);
    }

    private void MoveLeft()
    {
        rb.AddForceAtPosition(-transform.right * turnThrust * Time.deltaTime, leftBooster.position);
    }

    private void MoveRight()
    {
        rb.AddForceAtPosition(transform.right * turnThrust * Time.deltaTime, rightBooster.position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        CameraShake.instance.ShakeCamera(3f, 0.075f);

        if(health == 4)
        {
            heart5Anim.SetBool("isLost", true);
        }

        if(health == 3)
        {
            heart4Anim.SetBool("isLost", true);
        }

        if (health == 2)
        {
            heart3Anim.SetBool("isLost", true);
        }

        if (health == 1)
        {
            heart2Anim.SetBool("isLost", true);
        }

        if (health == 0)
        {
            heart1Anim.SetBool("isLost", true);
        }
    }
}

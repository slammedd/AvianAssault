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
    public ParticleSystem deathParticles;
    public ParticleSystem impactParticles;
    public Transform leftBooster;
    public Transform rightBooster;
    public Animator heart1Anim;
    public Animator heart2Anim;
    public Animator heart3Anim;
    public Animator heart4Anim;
    public Animator heart5Anim;
    public GameObject leftTrail;
    public GameObject rightTrail;

    [Header("Player Stats")]
    public float upThrust;
    public float turnThrust;
    public float maxSpeed;
    [Range(1, 10)] public float impactDamageSpeed;
    public float slowMotionTimeScale;
    private int health = 5;

    private float startTimeScale;
    private float startFixedDeltaTime;

    [Header("Camera")]
    public CinemachineVirtualCamera vCam;
    public float zoomSensitivity;

    private void Start()
    {
        vCam.m_Lens.OrthographicSize = 7.5f;
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
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

        StartSlowMotion(0.15f);

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
            Die();
        }
    } 

    public void Die()
    {
        CameraShake.instance.ShakeCamera(3f, 0.75f);
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.DOScale(0, 1f);
        leftTrail.SetActive(false);
        rightTrail.SetActive(false);
        StartSlowMotion(2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && rb.velocity.sqrMagnitude >= impactDamageSpeed)
        {
            ContactPoint2D contact = collision.contacts[0];
            Instantiate(impactParticles, contact.point, Quaternion.identity);
            TakeDamage(1);
        }
    }

    public void StartSlowMotion(float time)
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
        Invoke("StopSlowMotion", time);
    }

    public void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
}

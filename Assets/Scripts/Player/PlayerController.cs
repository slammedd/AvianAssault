using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.ShaderGraph;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public Rigidbody2D rb;
    public ParticleSystem upThrusterParticles;
    public Transform leftBooster;
    public Transform rightBooster;
    public float upThrust;
    public float turnThrust;
    public float maxSpeed;

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
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minDistance = 2;
    public float turnSpeed = 45; // degrees per second

    [Header("Camera")]
    public CinemachineVirtualCamera vCam;
    public float zoomSensitivity;

    Vector2 currentVelocity;

    private void Start()
    {
        vCam.m_Lens.OrthographicSize = 7.5f;
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Offsets the target position so that the object keeps its distance.
        mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
       
        Vector3 mousePosition3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition3d - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);

        vCam.m_Lens.OrthographicSize += Input.GetAxis("Mouse ScrollWheel");
        vCam.m_Lens.OrthographicSize = Mathf.Clamp(vCam.m_Lens.OrthographicSize, 4.5f, 10f);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance { get; private set; }

    private CinemachineVirtualCamera vCam;
    private float shakeTimer;

    private void Awake()
    {
        instance = this;
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }

        if(shakeTimer <= 0f)
        {
            CinemachineBasicMultiChannelPerlin perlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            perlin.m_AmplitudeGain = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraNoise : MonoBehaviour
{
    public static CameraNoise Instance { get; private set; }

    public CinemachineVirtualCamera Impulse;
    public float shakeTimer;

    public void Awake()
    {
        Instance = this;
        Impulse = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float ints, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            Impulse.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = ints;
        shakeTimer = time;
    }

    private void Update()
    {
        shakeTimer -= Time.deltaTime;

        if(shakeTimer <= 0f)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                Impulse.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }
    }
}
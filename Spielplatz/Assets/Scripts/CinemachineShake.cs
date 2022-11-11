using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineFreeLook freeLook;
    private float shakeTimer;

    public static CinemachineShake Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        freeLook = GetComponent<CinemachineFreeLook>();
        
        
    }
    public void ShakeCamera(float intensity,float time)
    {
        for (int i = 0; i < 3; i++)
        {
            CinemachineBasicMultiChannelPerlin cp = freeLook.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            
            cp.m_AmplitudeGain = intensity;
            
        }
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer>0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                for (int i = 0; i < 3; i++)
                {
                    
                    CinemachineBasicMultiChannelPerlin cp = freeLook.GetRig(i).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    cp.m_AmplitudeGain = 0f;
                }
            }
        }
    }
}

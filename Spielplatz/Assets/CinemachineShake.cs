using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineFreeLook freeLook;
    private CinemachineVirtualCamera bottomRig;
    private CinemachineVirtualCamera middleRig;
    private CinemachineVirtualCamera topRig;
    private float shakeTimer;

    public static CinemachineShake Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        freeLook = GetComponent<CinemachineFreeLook>();
        bottomRig = freeLook.GetRig(0);
        middleRig = freeLook.GetRig(1);
        topRig = freeLook.GetRig(2);
        
        
    }
    public void ShakeCamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cp_bottom = bottomRig.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cp_bottom.m_AmplitudeGain= intensity;
        //cp_bottom.m_PivotOffset= offset;
        CinemachineBasicMultiChannelPerlin cp_middle = middleRig.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cp_middle.m_AmplitudeGain = intensity;
        //cp_middle.m_PivotOffset= offset;
        CinemachineBasicMultiChannelPerlin cp_top = topRig.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cp_top.m_AmplitudeGain = intensity;
        //cp_top.m_PivotOffset= offset;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer>0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cp_bottom = bottomRig.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CinemachineBasicMultiChannelPerlin cp_middle = middleRig.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CinemachineBasicMultiChannelPerlin cp_top = topRig.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cp_bottom.m_AmplitudeGain = 0f;
                cp_middle.m_AmplitudeGain = 0f;
                cp_top.m_AmplitudeGain = 0f;
            }
        }
    }
}

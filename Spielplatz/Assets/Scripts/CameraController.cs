using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset;
    public bool camerashake_enable;
    private Transform cam;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Transform>();
        offset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {      
        if (shakeDuration > 0 && camerashake_enable)
        {
            cam.localPosition = (player.transform.position + offset) + Random.insideUnitSphere * shakeAmount;
           // transform.position = player.transform.position + offset;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            transform.position = player.transform.position + offset;
            shakeDuration = 0f;
            //cam.localPosition = originalPos;
        }
    }
}

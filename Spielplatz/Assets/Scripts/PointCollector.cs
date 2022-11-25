using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    [SerializeField]
    private AudioClip pickupSound;
    public PointManager pointmanager;
    public float volume;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position,volume);
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;
            pointmanager.AddPoint();
            
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.R)) {
            pointmanager.setZero();
        }
    }
}

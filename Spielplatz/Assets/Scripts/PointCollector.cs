using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    [SerializeField]
    private AudioClip pickupSound;
    public PointManager pointmanager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(other.gameObject);
            pointmanager.AddPoint();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour

{
    [SerializeField]
    private AudioClip levelExitSound;

    [SerializeField]
    private bool isEnabled = false;

    [SerializeField]
    private float rotationsSpeed = 1f;

    //private bool wasTouched = false;
   
   /* void OnTriggerEnter(Collider other)
    {
        if (!wasTouched && other.CompareTag("Player"))
        {
            isEnabled = true;
            AudioSource.PlayClipAtPoint(levelExitSound, Camera.main.transform.position);
            wasTouched = true;
        }
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            transform.Rotate(Vector3.up * rotationsSpeed, Space.World);
            
        }
    }
}

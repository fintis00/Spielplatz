using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorHandling : MonoBehaviour
{
    public Transform cam;
    [SerializeField]
    public GameObject door;
    [SerializeField]
    public GameObject particleObject;

    [SerializeField]
    private AudioClip doorSound;
    public float volume;
    public bool particleEnabled;

    bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            LeanTween.moveLocalX(door, -8, 4).setEaseInOutSine();
            AudioSource.PlayClipAtPoint(doorSound, cam.position, volume);
            if(particleEnabled == true)
            {
                Instantiate(particleObject, transform.position, Quaternion.identity);
            }
            
            isOpen = true;
            Invoke(nameof(CloseDoor), 7);
            }
    }

    private void CloseDoor()
    {
        LeanTween.moveLocalX(door, -5, 4).setEaseInOutSine();
        isOpen = false;
    }
    
}

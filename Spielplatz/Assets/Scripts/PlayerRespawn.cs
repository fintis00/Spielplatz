using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject respawn;
    public AudioClip audiRespawn;
    public float volume;
    public Transform cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("respawnPlane"))
        {

            GetComponent<Transform>().position = respawn.transform.position;
            AudioSource.PlayClipAtPoint(audiRespawn, cam.position, volume);
        }
    }
}
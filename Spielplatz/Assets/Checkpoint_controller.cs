using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_controller : MonoBehaviour
{

    public GameObject player;
    public GameObject checkpoint;
    public ParticleSystem system;
    public Color myColor;
    public Color white;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            system.Play();
            checkpoint.GetComponent<Renderer>().material.color = myColor;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableObject : MonoBehaviour
{
    public float hp;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageArea"))
        {
            hp--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            Object.Destroy(gameObject);
        }
    }
}

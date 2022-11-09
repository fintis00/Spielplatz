using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableObject : MonoBehaviour
{
    public float hp;
    public GameObject KillabeObjectParticle;
    public bool deathParticlesenabled;
    public bool hitColorChangeenabled;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageArea"))
        {
            hp--;
            if (hitColorChangeenabled == true)
            {
                GetComponent<Renderer>().material.color = Color.black;
                Invoke("ChangeColor", 0.1f);
            }                    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 1)
        {
            if(deathParticlesenabled == true)
                Instantiate(KillabeObjectParticle, GetComponent<Transform>().position, Quaternion.identity);
            Debug.Log("death");
            Object.Destroy(gameObject);
        }
    }
    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}

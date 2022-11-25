using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableObject : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public GameObject KillabeObjectParticle;
    public bool deathParticlesenabled;
    public bool hitColorChangeenabled;

    private void Start()
    {
        maxhp= hp;
    }
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
            if(deathParticlesenabled == true && GetComponent<MeshRenderer>().enabled)
                Instantiate(KillabeObjectParticle, GetComponent<Transform>().position, Quaternion.identity);
            
                GetComponent<Collider>().enabled = false;
                
            
            GetComponent<MeshRenderer>().enabled = false;
            deathParticlesenabled = false;


        }
        if(Input.GetKey(KeyCode.R))
        {
            hp = maxhp;
            deathParticlesenabled = true;
            
                GetComponent<Collider>().enabled = true;

            GetComponent<MeshRenderer>().enabled = true;
        }
       
    }
    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}

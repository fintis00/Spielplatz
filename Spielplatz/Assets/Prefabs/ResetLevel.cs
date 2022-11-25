using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    GameObject[] points;
    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>().position;
        rotation = GetComponent<Transform>().rotation;
        points = GameObject.FindGameObjectsWithTag("Points");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            resetPosition();
        }
    }

    void resetPosition()
    {
        GetComponent<Transform>().position = position;
        GetComponent<Transform>().rotation = rotation;

        for(int i = 0; i < points.Length; i++)
        {
            points[i].GetComponent<MeshRenderer>().enabled = true;
            points[i].GetComponent<Collider>().enabled = true;
        }
        for(int i =0;i<enemies.Length; i++)
        {
            enemies[i].GetComponent<MeshRenderer>().enabled = true;
            enemies[i].GetComponent<Collider>().enabled = true;
        }
        
    }
}

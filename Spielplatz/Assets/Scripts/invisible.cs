using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}

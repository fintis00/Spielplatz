using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashDamageArea : MonoBehaviour
{
    public float duration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, duration);

    }   
}
